using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace server
{
    class Program
    {
        static string RWType = "";
        static string addType = "";
        public static string CutString(string str)
        {
            string s = str;
            RWType = s[0].ToString();
            s = s.Substring(1);
            addType = s[0].ToString();
            s = s.Substring(1);
            return s;
        }

        static int port = 8005; // порт для приема входящих запросов

        static void Main(string[] args)
        {

            using (LibraryContext db = new LibraryContext())
            {
                string json_str = new JavaScriptSerializer().Serialize(db.Books.Find(2));
            }
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);

                // начинаем прослушивание
                listenSocket.Listen(10);

                Console.WriteLine("server started, wait connection");

                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[256]; // буфер для получаемых данных

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);
                    //получили

                

                    using (LibraryContext db = new LibraryContext())
                    {
                        string RecievedData = builder.ToString();
                                               
                        RecievedData = CutString(RecievedData);

                        //Получили запрос Find , возвращаем лист книг
                        if (RWType == "r")
                        {
                            if (addType == "1")
                            {
                                Book book = JsonConvert.DeserializeObject<Book>(RecievedData);
                                //string author = db.Authors.Find(book.AuthorId).Name;

                                //author, name, genre, publication date
                                List<Book> books = new List<Book>();
                                List<Book> help_book = new List<Book>();
                                bool flag = true;

                                if (book.AuthorId != -1)
                                {
                                    foreach (Book b in db.Books.ToList().FindAll(x => x.AuthorId == book.AuthorId))
                                    {
                                        help_book.Add(b);
                                    }
                                }
                                else
                                {
                                    help_book = db.Books.ToList();
                                }
                              

                              
                                if (book.Name != null && book.Name != "")
                                {
                                    foreach (Book b in db.Books.ToList().FindAll(x => x.Name == book.Name))
                                    {
                                        books.Add(b);
                                    }
                                } else
                                {
                                    books = db.Books.ToList();
                                }


                                    books = books.Intersect<Book>(help_book).ToList(); //перемножение множеств (листов) 
                                    help_book = new List<Book>();
                                


                                if (book.Genre != "" && book.Genre != null)
                                {
                                    foreach (Book b in db.Books.ToList().FindAll(x => x.Genre == book.Genre))
                                    {
                                        help_book.Add(b);
                                    }
                                } else
                                {
                                    help_book = db.Books.ToList();
                                }

                               
                                books = books.Intersect<Book>(help_book).ToList();
                                

                                /*
                                books = books.Intersect(help_book).ToList();
                                help_book = new List<Book>();

                                if (book.PublicationDate != null) { 
                                    foreach (Book b in db.Books.ToList().FindAll(x => x.PublicationDate == book.PublicationDate))
                                    {
                                        help_book.Add(b);
                                    }
                                }
                                */

                                //var unique_books = new HashSet<Book>(books).ToList();
                                string json_str = new JavaScriptSerializer().Serialize(books);
                                data = Encoding.Unicode.GetBytes(json_str);
                                handler.Send(data);
                            } else
                            {
                                Author author = JsonConvert.DeserializeObject<Author>(RecievedData);
                                List<Author> authors = new List<Author>();
                                authors = db.Authors.ToList();
                                                              
                                Console.WriteLine(authors[0]);
                                string json_str = new JavaScriptSerializer().Serialize(authors);
                                data = Encoding.Unicode.GetBytes(json_str);
                                handler.Send(data);
                            }

                        } else
                        {
                            //Получили запрос добавления автора
                            if (addType == "0") //author
                            {
                                Author obj = JsonConvert.DeserializeObject<Author>(RecievedData);
                                Console.WriteLine(obj);
                                db.Authors.Add(obj);
                                db.SaveChanges();
                            }
                            //Получили запрос добавления книги
                            if (addType == "1") //book
                            {
                                Book obj = JsonConvert.DeserializeObject<Book>(RecievedData);
                                Console.WriteLine(obj);
                                Console.WriteLine(db.Books.GetType());
                                db.Books.Add(obj);
                                db.SaveChanges();
                            }
                        }
                                                                                             

                    }

                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());

                    // отправляем ответ
                    //string message = "message received";
                    //data = Encoding.Unicode.GetBytes(message);
                    //handler.Send(data);
                    // закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
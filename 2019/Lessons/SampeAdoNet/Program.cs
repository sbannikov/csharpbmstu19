using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SampeAdoNet
{
    class Program
    {       
        static void Main(string[] args)
        {
            try
            {
                using (var db = new Database())
                {
                    Console.Write("Введите номер группы> ");
                    string group = Console.ReadLine();

                    // db.WorkAdoNet($"ИУ6-7{group}Б");

                    db.WorkDapper($"ИУ6-7{group}Б");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}

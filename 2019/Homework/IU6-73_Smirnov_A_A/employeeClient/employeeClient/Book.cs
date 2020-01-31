using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeClient
{
    class Book
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public int AuthorId { get; set; }
	}
}

/*
 * TABLE book
 * id
 * genre
 * name
 * publication date
 * authorId
 * 
*/

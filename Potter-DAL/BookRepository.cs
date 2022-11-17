using Potter_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potter_DAL
{
    public class BookRepository : IBookRepository
    {
        private readonly List<IBook> _books;
        public BookRepository(List<IBook> books)
        {
            _books = books;
        }  
        
        public List<IBook> GetAllBooks()
        {
            return _books;
        }
    }
}

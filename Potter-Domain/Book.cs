using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potter_Domain
{
    public class Book : IBook
    {
        public int BookId { get; set; }
        public string Title { get; set; }
    }
}

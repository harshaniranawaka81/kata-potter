using Potter_DAL;
using Potter_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potter_BLL
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly List<IBook> _books;

        private const double BOOK_PRICE = 8;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _books = _bookRepository.GetAllBooks();
        }
        public double CalculateBookCost()
        {
            var bookTypes = new Dictionary<string, int>();
            GetDifferentBookTypes(bookTypes);

            var bookBundles = new Dictionary<string, string>();
            GetDifferentBookBundles(bookBundles);
            var totalPrice = 0d;

            double discount;
            if (bookTypes.Count == 1)
            {
                discount = GetDiscountPercentage(bookTypes.Count);
                var total = BOOK_PRICE * _books.Count * (1 - discount);

                if (totalPrice == 0 || total < totalPrice)
                {
                    totalPrice = total;
                }
            }
            else if (bookTypes.Count >= 1)
            {
                foreach (var bundle in bookBundles)
                {
                    var values = bundle.Value.Split(",");

                    var total = 0d;

                    foreach (var value in values)
                    {
                        if (value == String.Empty) continue;

                        var noOfBooks = int.Parse(value);

                        if (bookTypes.Count < noOfBooks) break;

                        discount = GetDiscountPercentage(noOfBooks);
                        total += BOOK_PRICE * int.Parse(value) * (1 - discount);
                    }

                    Console.WriteLine($"{bundle.Key} - {bundle.Value} - {total}");

                    if (totalPrice == 0 || (total > 0 && total < totalPrice))
                    {
                        totalPrice = total;
                    }
                }
            }

            return totalPrice;
        }

        private void GetDifferentBookTypes(Dictionary<string, int> bookTypes)
        {
            foreach (var book in _books)
            {
                if (!bookTypes.ContainsKey(book.Title))
                {
                    bookTypes.Add(book.Title, GetBookCount(book.Title));
                }
            }
        }

        private int GetBookCount(string title)
        {
            return _books.Count(b => b.Title == title);
        } 
       
        private void GetDifferentBookBundles(Dictionary<string, string>  bookBundles)
        {
            for (int i = 1; i <= 5; i++)
            {
                var valueString = new StringBuilder();

                int remainingBooks = _books.Count;

                if (_books.Count < i) continue;

                while (remainingBooks > 0)
                {
                    if (i > remainingBooks)
                    {
                        valueString.Append($"{remainingBooks},");
                    }
                    else
                    {
                        valueString.Append($"{i},");
                    }
                    remainingBooks -= i;
                }

                bookBundles.Add(i.ToString(), valueString.ToString());
            }
        }

        private static double GetDiscountPercentage(int bookCount)
        {
            var discount = 0d;

            switch (bookCount)
            {
                case 5: discount = 0.25; break;
                case 4: discount = 0.2; break;
                case 3: discount = 0.1; break;
                case 2: discount = 0.05; break;
                case 1: discount = 0; break;
            }

            return discount;
        }

    }
}

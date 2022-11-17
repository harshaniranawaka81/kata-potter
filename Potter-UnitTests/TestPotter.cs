using Potter_BLL;
using Potter_DAL;
using Potter_Domain;
using System.Diagnostics;

namespace UnitTests
{
    [TestClass]
    public class TestPotter
    {
        private const double BOOK_PRICE = 8;

        [TestMethod]
        public void TestCase1()
        {
            var books = new List<IBook>();
            books.Add(new Book() { BookId = 1, Title = "First Book" });
            books.Add(new Book() { BookId = 2, Title = "First Book" });
            books.Add(new Book() { BookId = 3, Title = "Second Book" });
            books.Add(new Book() { BookId = 4, Title = "Second Book" });
            books.Add(new Book() { BookId = 5, Title = "Third Book" });
            books.Add(new Book() { BookId = 6, Title = "Third Book" });
            books.Add(new Book() { BookId = 1, Title = "Forth Book" });
            books.Add(new Book() { BookId = 1, Title = "Fifth Book" });

            var bookRepository = new BookRepository(books);
            var bookService = new BookService(bookRepository);

            var total = bookService.CalculateBookCost();
            Debug.Print(total.ToString());

            var expectedValue = 4 * BOOK_PRICE * 0.8 + 4 * BOOK_PRICE * 0.8;

            Assert.AreEqual(expectedValue, total);
        }

        [TestMethod]
        public void TestCase2()
        {
            var books = new List<IBook>();
            books.Add(new Book() { BookId = 1, Title = "First Book" });
            books.Add(new Book() { BookId = 2, Title = "Second Book" });
            books.Add(new Book() { BookId = 3, Title = "Third Book" });
            books.Add(new Book() { BookId = 4, Title = "First Book" });

            var bookRepository = new BookRepository(books);
            var bookService = new BookService(bookRepository);

            var total = bookService.CalculateBookCost();
            Debug.Print(total.ToString());

            var expectedValue = (BOOK_PRICE * 3 * 0.9) + BOOK_PRICE;

            Assert.AreEqual(expectedValue, total);
        }

        [TestMethod]
        public void TestCase3()
        {
            var books = new List<IBook>();
            books.Add(new Book() { BookId = 1, Title = "First Book" });
            books.Add(new Book() { BookId = 2, Title = "First Book" });
            books.Add(new Book() { BookId = 3, Title = "First Book" });

            var bookRepository = new BookRepository(books);
            var bookService = new BookService(bookRepository);

            var total = bookService.CalculateBookCost();
            Debug.Print(total.ToString());

            var expectedValue = BOOK_PRICE * 3;

            Assert.AreEqual(expectedValue, total);
        }


        [TestMethod]
        public void TestCase4()
        {
            var books = new List<IBook>();
            books.Add(new Book() { BookId = 1, Title = "First Book" });
            books.Add(new Book() { BookId = 2, Title = "First Book" });
            books.Add(new Book() { BookId = 3, Title = "Second Book" });

            var bookRepository = new BookRepository(books);
            var bookService = new BookService(bookRepository);

            var total = bookService.CalculateBookCost();
            Debug.Print(total.ToString());

            var expectedValue = (BOOK_PRICE * 2 * 0.95) + BOOK_PRICE;

            Assert.AreEqual(expectedValue, total);
        }

        [TestMethod]
        public void TestCase5()
        {
            var books = new List<IBook>();
            books.Add(new Book() { BookId = 1, Title = "First Book" });
            books.Add(new Book() { BookId = 2, Title = "Second Book" });

            var bookRepository = new BookRepository(books);
            var bookService = new BookService(bookRepository);

            var total = bookService.CalculateBookCost();
            Debug.Print(total.ToString());

            var expectedValue = (BOOK_PRICE * 2 * 0.95);

            Assert.AreEqual(expectedValue, total);
        }

        [TestMethod]
        public void TestCase6()
        {
            var books = new List<IBook>();
            books.Add(new Book() { BookId = 1, Title = "First Book" });
            books.Add(new Book() { BookId = 2, Title = "Second Book" });
            books.Add(new Book() { BookId = 3, Title = "Third Book" });
            books.Add(new Book() { BookId = 4, Title = "Forth Book" });
            books.Add(new Book() { BookId = 5, Title = "Fifth Book" });

            var bookRepository = new BookRepository(books);
            var bookService = new BookService(bookRepository);

            var total = bookService.CalculateBookCost();
            Debug.Print(total.ToString());

            var expectedValue = (BOOK_PRICE * 5 * 0.75);

            Assert.AreEqual(expectedValue, total);
        }
    }
}
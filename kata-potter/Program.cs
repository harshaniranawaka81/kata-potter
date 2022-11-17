// See https://aka.ms/new-console-template for more information

using Potter_BLL;
using Potter_DAL;
using Potter_Domain;
using static System.Reflection.Metadata.BlobBuilder;

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
Console.WriteLine($"Total Cost = {bookService.CalculateBookCost()}");
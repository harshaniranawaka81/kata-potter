using Potter_Domain;

namespace Potter_DAL
{
    public interface IBookRepository
    {
        List<IBook> GetAllBooks();
    }
}
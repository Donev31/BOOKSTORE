using BookStore.Models.Models;

namespace BookStore.BL.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooksByAuthorId(int authorId);
    }
}

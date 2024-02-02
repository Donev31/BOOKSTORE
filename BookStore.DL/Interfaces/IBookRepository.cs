using BookStore.Models.Models;

namespace BookStore.DL.Interfaces
{
    public interface IBookRepository
    {
        public void AddBook(Book book);

        public void DeleteBook(int id);

        public void UpdateBook(Book book);

        public Book? GetBook(int id);

        public List<Book> GetAllBooks();

        public List<Book> GetAllBooksByAuthorId(int id);
    }
}

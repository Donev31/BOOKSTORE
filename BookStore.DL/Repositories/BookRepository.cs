using BookStore.DL.InMemoryDb;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;

namespace BookStore.DL.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void AddBook(Book book)
        {
            StaticData.Books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var book =
                StaticData.Books
                    .FirstOrDefault(b => b.Id == id);

            if (book == null) return;

            StaticData.Books.Remove(book);
        }

        public void UpdateBook(Book book)
        {
            var existingBook =
                StaticData.Books
                    .FirstOrDefault(b => b.Id == book.Id);

            if (existingBook == null) return;

            existingBook.Title = book.Title;
        }

        public Book? GetBook(int id)
        {
            return
                StaticData.Books
                    .FirstOrDefault(b => b.Id == id);
        }

        public List<Book> GetAllBooks()
        {
            return StaticData.Books;
        }

        public List<Book> GetAllBooksByAuthorId(int id)
        {
            var result =
                StaticData.Books.Where(b => b.AuthorId == id)
                    .ToList();

            return result;
        }
    }
}

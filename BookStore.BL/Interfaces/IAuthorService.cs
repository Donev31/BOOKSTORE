using BookStore.Models.Models.Users;

namespace BookStore.BL.Interfaces
{
    public interface IAuthorService
    {
        List<Author> GetAll();

        Author GetById(int id);

        void Add(Author author);

        void Remove(int id);
    }
}

using BookStore.DL.Interfaces;
using BookStore.Models.Models.Users;

namespace BookStore.DL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public List<Author> GetAll()
        {
            return InMemoryDb.StaticData.AuthorsData;
        }

        public Author GetById(int id)
        {
            return InMemoryDb.StaticData.AuthorsData
                .First(a => a.Id == id);
        }

        public void Add(Author author)
        {
            InMemoryDb.StaticData.AuthorsData.Add(author);
        }

        public void Remove(int id)
        {
            var author = GetById(id);
            InMemoryDb.StaticData.AuthorsData.Remove(author);
        }
    }
}

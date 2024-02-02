using BookStore.Models.Models.Users;

namespace BookStore.DL.MemoryDb
{
    public static class InMemoryDb
    {
        public static List<Author> AuthorsData
            = new List<Author>()
            {
                new Author()
                {
                    Id = 1,
                    Name = "Name 1",
                    BirthDay = DateTime.Now
                },
                new Author()
                {
                    Id = 2,
                    Name = "Name 2",
                    BirthDay = DateTime.Now
                },
                new Author()
                {
                    Id = 3,
                    Name = "Name 3",
                    BirthDay = DateTime.Now
                },
            };
    }
}

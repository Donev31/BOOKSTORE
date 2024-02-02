using BookStore.Models.Models;
using BookStore.Models.Models.Users;

namespace BookStore.Models.Responses
{
    public class GetBooksByAuthorResponse
    {
        public Author Author { get; set; }

        public List<Book> Books { get; set; }
    }
}

using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.DL.Repositories;
using BookStore.Models.Models.Users;
using BookStore.Models.Models;
using Moq;

namespace BookTest
{
    public class LibraryServiceTests
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

        public static List<Book> BookData
            = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Book 1",
                    AuthorId = 1,
                    ReleaseDate = new DateTime(2005,05,07)
                },
                new Book()
                {
                    Id = 4,
                    Title = "Book 4",
                    AuthorId = 1,
                    ReleaseDate = new DateTime(2007,05,07)
                },
                new Book()
                {
                    Id = 2,
                    Title = "Book 2",
                    AuthorId = 2,
                    ReleaseDate = new DateTime(2015,05,07)
                },
                new Book()
                {
                    Id = 3,
                    Title = "Book 3",
                    AuthorId = 3,
                    ReleaseDate = new DateTime(2010,05,07)
                },
            };
        private int expectedCount;

        [Fact]
        public void CheckBookCountOK()
        {
            //setup
            var input = 10;
            var expectedCount = 14;

            var mockedBookRepository =
                new Mock<IBookRepository>();

            mockedBookRepository.Setup(
                    x => x.GetAllBooks())
                .Returns(BookData);

            //inject
            var bookService =
                new BookService(mockedBookRepository.Object);
            var authorService =
                new AuthorService(new AuthorRepository());
            var service = new LibraryService(
                authorService, bookService);

            //Act
            var result = service.CheckBookCount(input);

            //Assert
            Assert.Equal(
expectedCount, result);

        }


        public int GetExpectedCount()
        {
            return expectedCount;
        }

        [Fact]
        public void CheckBookCountNegativeInput()
        {
            //setup
            var input = -10;
            var expectedCount = 0;

            var mockedBookRepository =
                new Mock<IBookRepository>();

            mockedBookRepository.Setup(
                    x => x.GetAllBooks())
                .Returns(BookData);

            //inject
            var bookService =
                new BookService(mockedBookRepository.Object);
            var authorService =
                new AuthorService(new AuthorRepository());
            var service = new LibraryService(
                authorService, bookService);

            //Act
            var result = service.CheckBookCount(input);

            //Assert
            Assert.Equal(expectedCount, result);

        }

        [Fact]
        public void GetAllBooksByAuthorAfterReleaseDate_OK()
        {
            //setup
            var request = new GetAllBooksByAuthorRequest
            {
                AuthorId = 1,
                DateAfter = new DateTime(2000, 1, 1)
            };
            var expectedCount = 2;

            var mockedBookRepository =
                new Mock<IBookRepository>();
            var mockedAuthorRepository =
                new Mock<IAuthorRepository>();

            mockedBookRepository.Setup(
                    x =>
                        x.GetBooksByAuthorRequest(request.AuthorId))
                .Returns(BookData
                    .Where(b => b.AuthorId == request.AuthorId)
                    .ToList());

            mockedAuthorRepository.Setup(
                    x =>
                        x.GetById(request.AuthorId))
                .Returns(AuthorsData!
                    .FirstOrDefault(a =>
                        a.Id == request.AuthorId)!);

            //inject
            var bookService =
                new BookService(mockedBookRepository.Object);
            var authorService =
                new AuthorService(mockedAuthorRepository.Object);
            var service = new LibraryService(
                authorService, bookService);

            //Act
            var result =
                service.GetAllBooksByAuthorAfterReleaseDate(request);

            //Assert
            Assert.NotNull(result);
            object count = result.Books.Count;
            Assert.Equal(expectedCount, count);
            Assert.Equal(request.AuthorId,
                result.Author.Id);

        }
    }

    internal class GetAllBooksByAuthorRequest
    {
        public int AuthorId { get; set; }
        public DateTime DateAfter { get; set; }
    }
}
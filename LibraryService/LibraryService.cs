using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;

namespace Library
{
    /// <summary>
    /// Create a LibraryService to allow for the storing and accessing of books for a library.
    /// Note that the service persists its state between calls, so we can use a private list
    /// to store the books, as opposed to setting up a dedicated database. This information is lost
    /// when the service is ended
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class LibraryService : ILibraryService
    {
        private Random random = new Random();
        private List<Book> books = new List<Book>();
        private int bookNumber = 0;
        DateTime now = DateTime.Now;

        /// <summary>
        /// Create a LibraryService and create a number of books to initially populate the service
        /// </summary>
        public LibraryService()
        {
            books = CreateBooks();
        }

        /// <summary>
        /// Returns all of the current books
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAllBooks()
        {
            Thread.Sleep(5000);
            return books;
        }

        /// <summary>
        /// Save a book to the service - temporary
        /// </summary>
        public void SaveBook()
        {
            Thread.Sleep(5000);
        }

        /// <summary>
        /// Delete a book by title and author
        /// </summary>
        /// <param name="title">Title of the book</param>
        /// <param name="author">Author of the book</param>
        public void DeleteBook(string title, string author)
        {
            var bookToDelete = (from book in books
                where book.Title.Equals(title, StringComparison.InvariantCultureIgnoreCase)
                      && book.Author.Equals(author, StringComparison.InvariantCultureIgnoreCase)
                select book).FirstOrDefault();

            books.Remove(bookToDelete);

            Thread.Sleep(5000);
        }

        /// <summary>
        /// Create a random number of books with random properties for use in the BookManager
        /// </summary>
        /// <returns>A list of from 5 to 20 books with randomized properties</returns>
        private List<Book> CreateBooks()
        {
            var result = new List<Book>();

            for (int i = 0; i < random.Next(5, 20); i++)
            {
                result.Add(CreateBook());
            }

            return result;
        }

        /// <summary>
        /// Creates a book with random properties
        /// </summary>
        /// <returns>A book with random properties</returns>
        private Book CreateBook()
        {
            bookNumber++;

            var bookStatus = (BookStatus) random.Next(0, 2);
            Book book = new Book
            {
                Title = $"Book Title {bookNumber}",
                Author = $"Author {bookNumber}",
                BookStatus = bookStatus,
                DueDate = bookStatus != BookStatus.Borrowed ? now.AddDays(random.Next(1, 365)) : (DateTime?) null,
                Genre = (Genre) random.Next(0, 5),
                LibraryCode = $"Library Code {bookNumber}",
                Publisher = new Publisher
                {
                    Name = $"Publisher Name {bookNumber}",
                    Address = $"Address {bookNumber}"
                },
                Reviews = GenerateReviews(bookNumber)
            };

            return book;
        }

        /// <summary>
        /// Generate random reviews 
        /// </summary>
        /// <param name="bookNumber">The bookNumber of the book to create reviews for</param>
        /// <returns>A list of between 0 and 3 reviews</returns>
        private List<Review> GenerateReviews(int bookNumber)
        {
            var result = new List<Review>();
            var numberOfReviews = random.Next(0, 3);
            char reviewLetter = 'a';

            for (int i = 0; i < numberOfReviews; i++)
            {
                Review review = new Review
                {
                    ReviewerName = $"Reviewer {bookNumber}{reviewLetter}",
                    Comments = $"Comments {bookNumber}{reviewLetter}",
                    PercentScore = random.Next(0, 100)
                };

                result.Add(review);
                reviewLetter++;
            }

            return result;
        }
    }
}
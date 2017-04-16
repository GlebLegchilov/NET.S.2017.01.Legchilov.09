using System;
using System.IO;
using System.Collections.Generic;
using NLog;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Class manage books
    /// </summary>
    public class BookListService
    { 
        private static IMyLogger logger;
        private List<Book> bookList = new List<Book>();

        public BookListService(IMyLogger log)
        {
            if (log == null) throw new ArgumentNullException(nameof(log));
            logger = log;
        }

        public BookListService(IMyLogger log, IEnumerable<Book> list)
        {
            if (log == null) throw new ArgumentNullException(nameof(log));
            if (list == null) throw new ArgumentNullException(nameof(list));
            logger = log;
            bookList = (List<Book>)list;
        }

        /// <summary>
        /// Load book's list from file
        /// </summary>
        /// <param name="fileName">File's name</param>
        public void LoadData(IBookListStorage bookListStorage)
        {
            if (bookListStorage == null) throw new ArgumentNullException();
            bookList = bookListStorage.LoadData(logger);  
        }

        /// <summary>
        /// Save book's list in file
        /// </summary>
        /// <param name="fileName">File's name</param>
        public void SaveData(IBookListStorage bookListStorage)
        {
            if (bookListStorage == null) throw new ArgumentNullException();
            bookListStorage.StoreData(logger, bookList);
        }

        /// <summary>
        /// Add new book in list
        /// </summary>
        /// <param name="newBook">New book</param>
        public void AddBook(Book newBook)
        {
            logger.Debug("Adding a new book");
            if (newBook == null) throw new ArgumentNullException(nameof(newBook));
            if (bookList.Contains(newBook))
            {
                logger.Info("The book is already there");
                throw new Exception("The book is already there");
            }
            bookList.Add(newBook);
        }

        /// <summary>
        /// Delete book from list
        /// </summary>
        /// <param name="oldBook">Book to delete</param>
        public void RemoveBook(Book oldBook)
        {
            if (oldBook == null) throw new ArgumentNullException(nameof(oldBook));
            logger.Debug("Removing book from list");
            if (!bookList.Contains(oldBook))
            {
                logger.Info("The book for deletion not found");
                throw new Exception("Nothing to delete");
            }
            if (!bookList.Remove(oldBook))
            {
                logger.Warn("Can't delete book from bookList");
                throw new Exception("Can't delete book");
            }
        }

        /// <summary>
        /// Return book by tag
        /// </summary>
        /// <param name="type">Tag</param>
        /// <param name="element">Searching info</param>
        /// <returns>Book</returns>
        public Book FindBookByTag(IComparable<Book> tag)
        {
            logger.Debug("Finding book from list");
            if (tag == null) throw new ArgumentNullException(nameof(tag));

            foreach(Book book in bookList)
                if (tag.CompareTo(book) == 0)
                    return book;
            return null;

            
        }

        /// <summary>
        /// Sort list by some tag
        /// </summary>
        /// <param name="type">Tag</param>
        public void SortBookByTag(IComparer<Book> tag)
        {
            logger.Debug("Sorting book's list");
            if (tag == null) throw new ArgumentNullException(nameof(tag));
            
            bookList.Sort(tag);
        }
    }
}

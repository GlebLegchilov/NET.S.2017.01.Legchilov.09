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
        private static Delegate[] delegatesSort;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private List<Book> BookListStorage = new List<Book>();

        static BookListService()
        {
            Comparison<Book> comparisions = delegate(Book x, Book y)
                        {
                            if (x.Author == null && y.Author == null) return 0;
                            else if (x.Author == null) return -1;
                            else if (y.Author == null) return 1;
                            else return x.Author.CompareTo(y.Author);
                        };
            comparisions += delegate (Book x, Book y)
            {
                if (x.Name == null && y.Name == null) return 0;
                else if (x.Name == null) return -1;
                else if (y.Name == null) return 1;
                else return x.Name.CompareTo(y.Name);
            };
            comparisions += delegate (Book x, Book y)
            {
                if (x.PublishingHouse == null && y.PublishingHouse == null) return 0;
                else if (x.PublishingHouse == null) return -1;
                else if (y.PublishingHouse == null) return 1;
                else return x.PublishingHouse.CompareTo(y.PublishingHouse);
            };
            comparisions += delegate (Book x, Book y)
            {
                if (x.Text == null && y.Text == null) return 0;
                else if (x.Text == null) return -1;
                else if (y.Text == null) return 1;
                else return x.Text.CompareTo(y.Text);
            };
            delegatesSort = comparisions.GetInvocationList();
        }
        
        /// <summary>
        /// Load data from binary file
        /// </summary>
        /// <param name="fileName">File's name</param>
        public void LoadData(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException();
            logger.Debug("Loading book's list");
            using (Stream s = new FileStream(fileName, FileMode.Open))
            {
                var r = new BinaryReader(s);
                while (r.PeekChar() != -1)
                    AddBook(new Book(r.ReadString(), r.ReadString(), r.ReadString(), r.ReadString()));
            }   
        }

        /// <summary>
        /// Save data in binary file
        /// </summary>
        /// <param name="fileName">File's name</param>
        public void SaveData(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException();
            logger.Debug("Saving book's list");
            using (Stream s = new FileStream(fileName, FileMode.Create))
            {
                var w = new BinaryWriter(s);
                foreach (Book book in BookListStorage)
                {
                    w.Write(book.Name);
                    w.Write(book.Author);
                    w.Write(book.PublishingHouse);
                    w.Write(book.Text);
                }
                w.Flush();
            }
        }

        /// <summary>
        /// Add new book in list
        /// </summary>
        /// <param name="newBook">New book</param>
        public void AddBook(Book newBook)
        {
            logger.Debug("Adding a new book");
            if (newBook == null) throw new ArgumentNullException(nameof(newBook));
            if (BookListStorage.Contains(newBook))
            {
                logger.Info("The book is already there");
                throw new Exception("The book is already there");
            }        
            BookListStorage.Add(newBook);
        }

        /// <summary>
        /// Delete book from list
        /// </summary>
        /// <param name="oldBook">Book to delete</param>
        public void RemoveBook(Book oldBook)
        {
            if (oldBook == null) throw new ArgumentNullException(nameof(oldBook));
            logger.Debug("Removing book from list");
            if (!BookListStorage.Contains(oldBook))
            {
                logger.Info("The book for deletion not found");
                throw new Exception("Nothing to delete");
            }
            if (!BookListStorage.Remove(oldBook))
            {
                logger.Warn("Can't delete book from {0}", nameof(BookListStorage));
                throw new Exception("Can't delete book");
            }
        }

        /// <summary>
        /// Return book by tag
        /// </summary>
        /// <param name="type">Tag</param>
        /// <param name="element">Searching info</param>
        /// <returns>Book</returns>
        public Book FindBookByTag(Book.BookTypeSearch type, string element)
        {
            if (string.IsNullOrEmpty(element)) throw new ArgumentNullException(nameof(element));
            logger.Debug("Finding book from list");
            Book result;
            switch (type)
            {
                case Book.BookTypeSearch.Author:
                    result = BookListStorage.Find(x => x.Author == element);
                    break;
                case Book.BookTypeSearch.Name:
                    result = BookListStorage.Find(x => x.Name == element);
                    break;
                case Book.BookTypeSearch.PublishingHouse:
                    result = BookListStorage.Find(x => x.PublishingHouse == element);
                    break;
                default:
                    result = BookListStorage.Find(x => x.Text == element);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Sort list by some tag
        /// </summary>
        /// <param name="type">Tag</param>
        public void SortBookByTag(Book.BookTypeSearch type)
        {
            logger.Debug("Sorting book's list");
            BookListStorage.Sort((Comparison<Book>)delegatesSort[(int)type]);
        }
    }
}

using System;
using System.Collections;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using NLog;

namespace Task1
{
    /// <summary>
    /// Class storing information about the book
    /// </summary>
    public class Book : IComparer, IComparable
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public enum BookTypeSearch
        {
            Name = 0,
            Author,
            PublishingHouse,
            Text
        }

        public string Name { get; private set; }
        public string Author { get; private set; }
        public string PublishingHouse { get; private set; }
        public string Text { get; private set; }


        /// <summary>
        /// Create and initialize new Book object 
        /// </summary>
        /// <param name="name">Book's name</param>
        /// <param name="author">Author's name</param>
        /// <param name="publishingHouse">Publishing house's name</param>
        /// <param name="text">Book's text</param>
        public Book(string name, string author, string publishingHouse, string text)
        {
            logger.Debug("Reqest for creating new book");
            if (string.IsNullOrEmpty(name))
            {
                logger.Info("Parameter name is null");
                throw new ArgumentNullException(nameof(name));
            }
            if (string.IsNullOrEmpty(author))
            {
                logger.Info("Parameter author is null");
                throw new ArgumentNullException(nameof(author));
            }
            if (string.IsNullOrEmpty(publishingHouse))
            {
                logger.Info("Parameter publishingHouse is null");
                throw new ArgumentNullException(nameof(publishingHouse));
            }
            if (string.IsNullOrEmpty(text))
            {
                logger.Info("Parameter text is null");
                throw new ArgumentNullException(nameof(text));
            }
            Name = name;
            Author = author;
            PublishingHouse = publishingHouse;
            Text = text;
        }

        #region Equals
        /// <summary>
        /// Check for equality curent and param books
        /// </summary>
        /// <param name="book">Book to compare</param>
        /// <returns>Result</returns>
        public bool Equals(Book book)
        {
            if (ReferenceEquals(null, book)) return false;
            if (ReferenceEquals(this, book)) return true;

            return Equals(this, book);
        }

        /// <summary>
        /// Check for equality two books
        /// </summary>
        /// <param name="x">First book</param>
        /// <param name="y">Second book</param>
        /// <returns>Result</returns>
        public static bool Equals(Book x, Book y)
        {
            if (ReferenceEquals(x, null) && ReferenceEquals(y, null)) return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;

            return (( x.Text == y.Text) && (x.Name == y.Name) && (x.Author == y.Author));
        }

        /// <summary>
        /// Check for equality curent and param books
        /// </summary>
        /// <param name="obj">Book to compare</param>
        /// <returns>Result</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals(this, obj as Book);
        }

        /// <summary>
        /// Check for equality two books
        /// </summary>
        /// <param name="lhs">First book</param>
        /// <param name="rhs">Second book</param>
        /// <returns>Result</returns>
        public static bool operator ==(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null)) return true;
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) return false;

            return Equals(lhs as Book, rhs as Book);
        }

        /// <summary>
        /// Check for inequality two books
        /// </summary>
        /// <param name="lhs">First book</param>
        /// <param name="rhs">Second book</param>
        /// <returns>Result</returns>
        public static bool operator !=(Book lhs, Book rhs)
        {
            return !(lhs == rhs);
        }
        #endregion

        #region Compare, CompareTo
        /// <summary>
        /// Compare two books
        /// </summary>
        /// <param name="x">First book</param>
        /// <param name="y">Second book</param>
        /// <returns>Result</returns>
        public static int Compare(Book x, Book y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) throw new ArgumentNullException();

            if (x.Text.Length > y.Text.Length) return 1;
            else if (x.Text.Length < y.Text.Length) return -1;
            else return 0;
        }

        /// <summary>
        /// Compare two books
        /// </summary>
        /// <param name="x">First book</param>
        /// <param name="y">Second book</param>
        /// <returns>Result</returns>
        public int Compare(object x, object y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) throw new ArgumentNullException();
            if (x.GetType() != y.GetType()) throw new ArgumentException();
            return Compare(x as Book, y as Book);
        }

        /// <summary>
        /// Compare curent and param books
        /// </summary>
        /// <param name="obj">Book to compare</param>
        /// <returns>Result</returns>
        public int CompareTo(object obj)
        {
            if ( ReferenceEquals(obj, null)) throw new ArgumentNullException();
            if (obj.GetType() != this.GetType()) throw new ArgumentException();
            return Compare(this, obj as Book);
        }

        /// <summary>
        /// Compare two books
        /// </summary>
        /// <param name="lhs">First book</param>
        /// <param name="rhs">Second book</param>
        /// <returns>Result</returns>
        public static bool operator >(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) throw new ArgumentNullException();
            if (Compare(lhs as Book, rhs as Book) > 0) return true;
            else return false;
        }

        /// <summary>
        /// Compare two books
        /// </summary>
        /// <param name="lhs">First book</param>
        /// <param name="rhs">Second book</param>
        /// <returns>Result</returns>
        public static bool operator <(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) throw new ArgumentNullException();
            if (Compare(lhs as Book, rhs as Book) < 0) return true;
            else return false;
        }
        #endregion

        /// <summary>
        /// Return book's object string representation 
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return string.Format("\"{0}\" {1}", Name, Author);
        }

        /// <summary>
        /// Return book's object hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return Text.GetHashCode();
        }
    }
}

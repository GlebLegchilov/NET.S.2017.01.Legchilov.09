using System;

namespace Task1
{
    /// <summary>
    /// Class storing information about the book
    /// </summary>
    [Serializable]
    public sealed class Book : IEquatable<Book>, IComparable, IComparable<Book>
    {
        public string Name { get;}
        public string Author { get;}
        public string PublishingHouse { get;}
        public string Text { get;}


        /// <summary>
        /// Create and initialize new Book object 
        /// </summary>
        /// <param name="name">Book's name</param>
        /// <param name="author">Author's name</param>
        /// <param name="publishingHouse">Publishing house's name</param>
        /// <param name="text">Book's text</param>
        public Book(string name, string author, string publishingHouse, string text)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(author)) throw new ArgumentNullException(nameof(author));
            if (string.IsNullOrEmpty(publishingHouse)) throw new ArgumentNullException(nameof(publishingHouse)); 
            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException(nameof(text));
            
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

            if ((Name == book.Name)&&(Author == book.Author)) return true;
            return false;
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
        #endregion

        #region CompareTo

        /// <summary>
        /// Compare curent and param books
        /// </summary>
        /// <param name="obj">Book to compare</param>
        /// <returns>Result</returns>
        int IComparable.CompareTo(object obj)
        {
            if ( ReferenceEquals(obj, null)) throw new ArgumentNullException();
            if (obj.GetType() != this.GetType()) throw new ArgumentException();

            return CompareTo(obj as Book);
        }

        /// <summary>
        /// Compare curent and param books
        /// </summary>
        /// <param name="book">Book to compare</param>
        /// <returns>Result</returns>
        public int CompareTo(Book book)
        {
            if (ReferenceEquals(book, null)) throw new ArgumentNullException();

            if (this.Text.Length > book.Text.Length) return 1;
            else if (this.Text.Length < book.Text.Length) return -1;
            else return 0;
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

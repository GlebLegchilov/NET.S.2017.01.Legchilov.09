using System;
using Task1;

namespace Task1ConsoleApplication
{
    class ComparableByName : IFindByTag
    {
        public string Tag { get; }
        public ComparableByName(string tag)
        {
            if (string.IsNullOrEmpty(tag)) throw new ArgumentNullException(nameof(tag));
            Tag = tag;
        }
        public int CompareTo(Book book)
        {
            if (book == null) return 0;
            else if (Tag == null) return -1;
            else if (book.Name == null) return 1;
            else return Tag.CompareTo(book.Name);
        }
    }

    class ComparableByAuthor : IFindByTag
    {
        public string Tag { get; }
        public ComparableByAuthor(string tag)
        {
            if (string.IsNullOrEmpty(tag)) throw new ArgumentNullException(nameof(tag));
            Tag = tag;
        }
        public int CompareTo(Book book)
        {
            if (book == null) return 0;
            else if (Tag == null) return -1;
            else if (book.Author == null) return 1;
            else return Tag.CompareTo(book.Author);
        }
    }
    class ComparableByPH : IFindByTag
    {
        public string Tag { get; }
        public ComparableByPH(string tag)
        {
            if (string.IsNullOrEmpty(tag)) throw new ArgumentNullException(nameof(tag));
            Tag = tag;
        }
        public int CompareTo(Book book)
        {
            if (book == null) return 0;
            else if (Tag == null) return -1;
            else if (book.PublishingHouse == null) return 1;
            else return Tag.CompareTo(book.PublishingHouse);
        }
    }
    class ComparableByText : IFindByTag
    {
        public string Tag { get; }
        public ComparableByText(string tag)
        {
            if (string.IsNullOrEmpty(tag)) throw new ArgumentNullException(nameof(tag));
            Tag = tag;
        }
        public int CompareTo(Book book)
        {
            if (book == null) return 0;
            else if (Tag == null) return -1;
            else if (book.Text == null) return 1;
            else return Tag.CompareTo(book.Text);
        }
    }
}

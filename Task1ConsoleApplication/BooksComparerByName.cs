using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1ConsoleApplication
{
    class BooksComparerByName: IComparer<Book>
    {
        public int  Compare(Book x, Book y)
        {
            if (x.Name == null && y.Name == null) return 0;
            else if (x.Name == null) return -1;
            else if (y.Name == null) return 1;
            else return x.Name.CompareTo(y.Name);
        }
    }

    class BooksComparerByAuthor : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Author == null && y.Author == null) return 0;
            else if (x.Author == null) return -1;
            else if (y.Author == null) return 1;
            else return x.Author.CompareTo(y.Author);
        }
    }

    class BooksComparerByPH : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.PublishingHouse == null && y.PublishingHouse == null) return 0;
            else if (x.PublishingHouse == null) return -1;
            else if (y.PublishingHouse == null) return 1;
            else return x.PublishingHouse.CompareTo(y.PublishingHouse);
        }
    }

    class BooksComparerByText : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Text == null && y.Text == null) return 0;
            else if (x.Text == null) return -1;
            else if (y.Text == null) return 1;
            else return x.Text.CompareTo(y.Text);
        }
    }


}

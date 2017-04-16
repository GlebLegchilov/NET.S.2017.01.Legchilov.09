using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Task1;

namespace Task1ConsoleApplication
{
    class BookListStorage : IBookListStorage
    {
        public string FileName { get; set; }

        public  BookListStorage(string fileName = "books.txt")
        {
            FileName = fileName;
        }

        public void StoreData(IMyLogger logger, IEnumerable<Book> books)
        {
            logger.Debug("Saving book's list");
            using (Stream s = new FileStream(FileName, FileMode.Create))
            {
                var w = new BinaryWriter(s);
                foreach (Book book in books)
                {
                    w.Write(book.Name);
                    w.Write(book.Author);
                    w.Write(book.PublishingHouse);
                    w.Write(book.Text);
                }
                w.Flush();
            }
        }

        public List<Book> LoadData(IMyLogger logger)
        {
            List<Book> result = new List<Book>();
            logger.Debug("Loading book's list");
            using (Stream s = new FileStream(FileName, FileMode.Open))
            {
                var r = new BinaryReader(s);
                while (r.PeekChar() != -1)
                    result.Add(new Book(r.ReadString(), r.ReadString(), r.ReadString(), r.ReadString()));
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using System.Xml.Linq;

namespace Task1ConsoleApplication
{
    /// <summary>
    /// Class strore books to xml formate
    /// </summary>
    class XMLStorage : IBookListStorage
    {
        #region Propertis

        /// <summary>
        /// Store file name
        /// </summary>
        public string FileName { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Initialize object with file name
        /// </summary>
        /// <param name="fileName"Store file name></param>
        public XMLStorage(string fileName = "books.xml")
        {
            FileName = fileName;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Store list of books in xml formate
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="books">List of books</param>
        public void StoreData(IMyLogger logger, IEnumerable<Book> books)
        {
            logger.Debug("Saving book's list");

            XDocument xdoc = new XDocument();
            XElement phones = new XElement("books");
            XElement book;
            foreach (var item in books)
            {
                book = new XElement("book");
                book.Add(new XAttribute("name", item.Name));
                book.Add(new XElement("author", item.Author));
                book.Add(new XElement("text", item.Text));
                book.Add(new XElement("ph", item.PublishingHouse));  
                phones.Add(book);
            }
            xdoc.Add(phones);
            xdoc.Save(FileName);
        }

        /// <summary>
        /// Load books from file in xml formate
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <returns>List of books</returns>
        public List<Book> LoadData(IMyLogger logger)
        {
            List<Book> result = new List<Book>() ;
            logger.Debug("Loading book's list");

            XDocument xdoc = XDocument.Load(FileName);
            foreach (XElement bookElement in xdoc.Element("books").Elements("book"))
            {
                XAttribute nameAttribute = bookElement.Attribute("name");
                XElement authorElement = bookElement.Element("author");
                XElement textElement = bookElement.Element("text");
                XElement phElement = bookElement.Element("ph");

                if (nameAttribute != null && authorElement != null && phElement != null && textElement != null)
                    result.Add(new Book(nameAttribute.Value, authorElement.Value, phElement.Value, textElement.Value));
            }
            return result;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task1ConsoleApplication
{

    /// <summary>
    /// Class store books using serialization
    /// </summary>
    class BinarySerializerStorage : IBookListStorage
    {
        #region Propertis

        /// <summary>
        /// Store file name
        /// </summary>
        public string FileName { get; set; }
        #endregion

        #region Constructors

        /// <summary>
        ///  Initialize object with file name
        /// </summary>
        /// <param name="fileName">Store file name</param>
        public BinarySerializerStorage(string fileName = "books.dat")
        {
            FileName = fileName;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Store serialized list of books in binary file
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="books">List of books</param>
        public void StoreData(IMyLogger logger, IEnumerable<Book> books)
        {
            logger.Debug("Saving book's list");

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
                    formatter.Serialize(fs, books);
        }

        /// <summary>
        /// Load books from binary file and deserialize it
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <returns>List of books</returns>
        public List<Book> LoadData(IMyLogger logger)
        {
            List<Book> result;
            logger.Debug("Loading book's list");

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
                result = (List<Book>)formatter.Deserialize(fs);
            
            return result;
        }
        #endregion
    }
}

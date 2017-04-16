using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Task1
{
    public interface IBookListStorage
    {
        void StoreData(IMyLogger logger, IEnumerable<Book> books);

        List<Book> LoadData(IMyLogger logger);
    }
}

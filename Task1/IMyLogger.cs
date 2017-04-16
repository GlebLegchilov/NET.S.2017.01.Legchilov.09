using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface IMyLogger
    {
        void Debug(string value);

        void Info(string value);

        void Error(string value);

        void Warn(string value);

        void Fatal(string value);
        
    }
}

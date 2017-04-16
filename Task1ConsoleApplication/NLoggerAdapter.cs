using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using NLog;

namespace Task1ConsoleApplication
{
    class NLoggerAdapter: IMyLogger
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        public void Debug(string value)
        {
            logger.Debug(value);
        }

        public void Info(string value)
        {
            logger.Info(value);
        }
        public void Error(string value)
        {
            logger.Error(value);
        }
        public void Warn(string value)
        {
            logger.Warn(value);
        }
        public void Fatal(string value)
        {
            logger.Fatal(value);
        }


    }
}

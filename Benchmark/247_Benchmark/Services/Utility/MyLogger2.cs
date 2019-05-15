using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;

namespace _247_Benchmark.Services.Utility
{
    class MyLogger2 : ILogger
    {
        private static Logger logger;

        public void Debug(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Debug(message);
            else
                GetLogger("myAppLoggerRules").Debug(message, arg);
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Error(message);
            else
                GetLogger("myAppLoggerRules").Error(message, arg);
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Info(message);
            else
                GetLogger("myAppLoggerRules").Info(message, arg);
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Warn(message);
            else
                GetLogger("myAppLoggerRules").Warn(message, arg);
        }

        private Logger GetLogger(string theLogger)
        {
            if (MyLogger2.logger == null)
                MyLogger2.logger = LogManager.GetLogger(theLogger);
            return MyLogger2.logger;
        }
    }
}
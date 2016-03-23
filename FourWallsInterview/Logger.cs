using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWallsInterview
{
    /// <summary>
    /// This class is designed to perform a basic logging function.
    /// In the future, we might want to expand our logging capabilities. 
    /// 
    /// Currently, this class doesn't follow SOLID and would require too much modification to extext. 
    /// It violates the Open Close Principle. 
    /// 
    /// Please refactor this method and provide tests in FourWallsInterview.UnitTests.LoggerTests.LogShould.
    /// 
    /// 
    /// Hint:
    /// 
    /// public class ConsoleLogger : IMessageLogger {}
    /// public class QueueLogger : IMessageLogger {}
    /// </summary>
    public class Logger
    {
        private IMessageLogger _messageLogger;
        
        public IMessageLogger MessageLogger
        {
            get
            {
                return _messageLogger;
            }

            set
            {
                _messageLogger = value;
            }
        }

        public Logger() : this(LogType.Console)
        {
        }

        public Logger(LogType logType)
        {
            switch (logType)
            {
                case LogType.Console:
                    MessageLogger = new ConsoleLogger();
                    break;

                case LogType.Queue:
                    MessageLogger = new QueueLogger();
                    break;
            }
        }

        public void Log(string message)
        {
            MessageLogger.Log(message);
        }
    }


    public enum LogType
    {
        Console,
        Queue
    }
    
}

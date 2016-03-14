using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWallsInterview
{
    ///// <summary>
    ///// Refactor this method to use the Open Close Principle
    ///// </summary>
    //public class Logger
    //{
    //    public void Log(string message, LogType logType)
    //    {
    //        switch (logType)
    //        {
    //            case LogType.Console:
    //                Console.WriteLine(message);
    //                break;

    //            case LogType.File:
    //                // Code to send message to printer
    //                break;
    //        }
    //    }
    //}


    //public enum LogType
    //{
    //    Console,
    //    File
    //}


    public class Logger
    {

        IMessageLogger _messageLogger;

        public Logger(IMessageLogger messageLogger)
        {
            _messageLogger = messageLogger;
        }

        public void Log(string message)
        {
            _messageLogger.Log(message);
        }
    }


    public interface IMessageLogger
    {
        void Log(string message);
    }
}

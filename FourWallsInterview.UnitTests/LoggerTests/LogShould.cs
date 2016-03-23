using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace FourWallsInterview.UnitTests.LoggerTests
{
    public class LogShould
    {
        /// <summary>
        /// Please refactor FourWallsInterview.Logger and verify that the 
        /// Log method is being called correctly
        /// </summary>
        [Theory, 
            InlineData("Console test 1", LogType.Console),
            InlineData("Console test 2", null),
            InlineData("Queue test", LogType.Queue)]
        public void Call_Log_with_message(string message, LogType? logType)
        {
            Mock<Logger> mock;
            Logger logger;
            if (logType.HasValue)
            {
                mock = new Mock<Logger>(logType.Value);
                logger = mock.Object;
                switch (logType)
                {
                    case LogType.Console:
                        Assert.IsAssignableFrom(typeof(ConsoleLogger), logger.MessageLogger);
                        break;
                    case LogType.Queue:
                        Assert.IsAssignableFrom(typeof(QueueLogger), logger.MessageLogger);
                        break;
                }
            }
            else
            {
                mock = new Mock<Logger>();
                logger = mock.Object;
                Assert.IsAssignableFrom(typeof(ConsoleLogger), logger.MessageLogger);
            }
            logger.Log(message);
        }
    }
}

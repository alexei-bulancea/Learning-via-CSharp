using System;

/// <summary>
/// The Chain of Responsibility design pattern is one of the twenty-three well-known GoF design patterns that describe common solutions to recurring design problems when designing flexible and reusable object-oriented software, that is, objects that are easier to implement, change, test, and reuse.

//What problems can the Chain of Responsibility design pattern solve?

//Coupling the sender of a request to its receiver should be avoided.
//It should be possible that more than one receiver can handle a request.
//Implementing a request directly within the class that sends the request is inflexible because it couples the class to a particular receiver and makes it impossible to support multiple receivers.

//What solution does the Chain of Responsibility design pattern describe?

//Define a chain of receiver objects having the responsibility, depending on run-time conditions, to either handle a request or forward it to the next receiver on the chain(if any).
//This enables to send a request to a chain of receivers without having to know which one handles the request.The request gets passed along the chain until a receiver handles the request. The sender of a request is no longer coupled to a particular receiver.
/// </summary>
/// 
namespace Learning.Patterns
{
    [Flags]
    public enum LogLevel
    {
        None = 0,                 //        0
        Info = 1,                 //        1
        Debug = 2,                //       10
        Warning = 4,              //      100
        Error = 8,                //     1000
        FunctionalMessage = 16,   //    10000
        FunctionalError = 32,     //   100000
        All = 63                  //   111111
    }

    public abstract class Logger
    {
        protected LogLevel level;

        protected Logger nextLogger;

        public Logger(LogLevel logLevel)
        {
            this.level = logLevel;
        }

        public Logger SetNext(Logger nextLogger)
        {
            var lastLogger = this;

            while(lastLogger.nextLogger != null)
            {
                lastLogger = lastLogger.nextLogger;
            }

            lastLogger.nextLogger = nextLogger;
            return this;
        }

        public void Message(string message, LogLevel logLevel )
        {
            if((this.level & logLevel) != 0)
            {
                WriteMessage(message);
            }
            if(nextLogger != null)
            {
                nextLogger.Message(message, logLevel);
            }
        }

        protected abstract void WriteMessage(string message);

    }

    public class DbLogger : Logger
    {
        public DbLogger(LogLevel logLevel) : base (logLevel)
        {
            
        }

        protected override void WriteMessage(string message)
        {
            Console.WriteLine("Logged to Database.");
        }
    }

    public class ConsoleLogger : Logger
    {
        public ConsoleLogger(LogLevel logLevel) : base(logLevel)
        {

        }

        protected override void WriteMessage(string message)
        {
            Console.WriteLine("Logged to Console.");
        }
    }

    public class FileLogger : Logger
    {
        public FileLogger(LogLevel logLevel) : base(logLevel)
        {

        }

        protected override void WriteMessage(string message)
        {
            Console.WriteLine("Logged to File.");
        }
    }


    public class ChainOfResponsibility
    {
        public ChainOfResponsibility()
        {
            Logger logger;
            logger = new ConsoleLogger(LogLevel.All)
                            .SetNext(new DbLogger(LogLevel.Debug))
                            .SetNext(new FileLogger(LogLevel.Error));

            logger.Message("Error encountered",LogLevel.Error);

            Console.ReadKey();
        }

    }
}

using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            LogSubject logsubject = new LogSubject();
            EmailLogger emailLogger = new EmailLogger(logsubject);
            FileLogger fileLogger = new FileLogger(logsubject);
            DBLogger dbLogger = new DBLogger(logsubject);
            KibanaLogger kibanaLogger = new KibanaLogger(logsubject);
            logsubject.LogEvent(new LogRequest());
            Console.WriteLine("----------------------------------------");
            kibanaLogger.LogSubject.DeAttach(kibanaLogger);
            logsubject.LogEvent(new LogRequest());
            Console.WriteLine("----------------------------------------");

            MQLogger mqLogger = new MQLogger(logsubject);

            logsubject.LogEvent(new LogRequest());
            Console.WriteLine("----------------------------------------");
        }
    }

    public interface ILogSubject
    {
        void Attach(ILogObserver observer);
        void DeAttach(ILogObserver observer);
        void LogEvent(LogRequest request);
    }

    public class LogSubject : ILogSubject
    {
        List<ILogObserver> objList = new List<ILogObserver>();
        public void Attach(ILogObserver observer)
        {
            if(!objList.Contains(observer))
            objList.Add(observer);
        }

        public void DeAttach(ILogObserver observer)
        {
            if (objList.Contains(observer))
                objList.Remove(observer);
        }

        public void LogEvent(LogRequest request)
        {
            foreach (var item in objList)
            {
                item.LogEvent(request);
            }
        }
    }

    public class LogRequest
    {

    }

    public interface ILogObserver
    {
        void LogEvent(LogRequest request);
    }

    public abstract class LogObserver : ILogObserver
    {
        public LogObserver(LogSubject subject)
        {
            this.LogSubject = subject;
            this.LogSubject.Attach(this);
        }

        public LogSubject LogSubject { get; set; }
        public abstract void LogEvent(LogRequest request);
    }

    public class FileLogger : LogObserver
    {
        public FileLogger(LogSubject subject) : base(subject)
        {

        }
        public override void LogEvent(LogRequest request)
        {
            Console.WriteLine("Logu Aldım ve işledim Teşekkürler - " + this.ToString());
        }
    }

    public class EmailLogger : LogObserver
    {
        public EmailLogger(LogSubject subject) : base(subject)
        {

        }
        public override void LogEvent(LogRequest request)
        {
            Console.WriteLine("Logu Aldım ve işledim Teşekkürler - " + this.ToString());
        }
    }

    public class DBLogger : LogObserver
    {
        public DBLogger(LogSubject subject) : base(subject)
        {

        }
        public override void LogEvent(LogRequest request)
        {
            Console.WriteLine("Logu Aldım ve işledim Teşekkürler - " + this.ToString());
        }
    }

    public class KibanaLogger : LogObserver
    {
        public KibanaLogger(LogSubject subject) : base(subject)
        {

        }
        public override void LogEvent(LogRequest request)
        {
            Console.WriteLine("Logu Aldım ve işledim Teşekkürler - " + this.ToString());
        }
    }

    public class MQLogger : LogObserver
    {
        public MQLogger(LogSubject subject) : base(subject)
        {

        }
        public override void LogEvent(LogRequest request)
        {
            Console.WriteLine("Logu Aldım ve işledim Teşekkürler - " + this.ToString());
        }
    }

}

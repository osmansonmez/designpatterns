using System;
using System.Collections.Generic;

namespace ObserverPatternSample1
{
    class Program
    {
        static void Main(string[] args)
        {
            LogSubject logsubject = new LogSubject();

            FileLogger fl = new FileLogger(logsubject);
            DBLogger dbl = new DBLogger(logsubject);
            MailLogger ml = new MailLogger(logsubject);

            logsubject.Process(new LogRequest()
            { logType = LogTypeEnum.Error });

            Console.WriteLine("-------------------------");

            logsubject.Process(new LogRequest()
            { logType = LogTypeEnum.Debug });

            Console.WriteLine("-------------------------");

            logsubject.Process(new LogRequest()
            { logType = LogTypeEnum.RequestResponse });

            Console.WriteLine("-------------------------");

            dbl.subject.DeAttach(dbl);


            logsubject.Process(new LogRequest()
            { logType = LogTypeEnum.Error });

            Console.WriteLine("-------------------------");

            logsubject.Process(new LogRequest()
            { logType = LogTypeEnum.Debug });

            Console.WriteLine("-------------------------");

            logsubject.Process(new LogRequest()
            { logType = LogTypeEnum.RequestResponse });

            Console.WriteLine("-------------------------");
        }
    }

    public interface ILogSubject
    {
        void Attach(ILogObserver item);

        void DeAttach(ILogObserver item);

        void Process(LogRequest request); 
    }

    public class LogSubject : ILogSubject
    {
        List<ILogObserver> items = new List<ILogObserver>();
        public void Attach(ILogObserver item)
        {
            items.Add(item);
        }

        public void DeAttach(ILogObserver item)
        {
            items.Remove(item);
        }

        public void Process(LogRequest request)
        {
            Notify(request);
        }
        private void Notify(LogRequest request)
        {
            foreach (var item in items)
            {
                item.Notify(request);
            }
        }
    }

    public class LogRequest
    {
        public LogTypeEnum logType;
    }

    public enum LogTypeEnum
    {
        RequestResponse,
        Error,
        Warning,
        Info,
        Debug
    }

    public abstract class ILogObserver
    {
        public ILogSubject subject;

        public ILogObserver(ILogSubject subject)
        {
            this.subject = subject;
            subject.Attach(this);
        }
        public abstract void Notify(LogRequest request);
    }

    public class FileLogger : ILogObserver
    {
        public FileLogger(ILogSubject subject):base(subject)
        {

        }
        public override void Notify(LogRequest request)
        {
           switch(request.logType)
            {
                case LogTypeEnum.Debug:
                case LogTypeEnum.Error:
                case LogTypeEnum.Info:
                case LogTypeEnum.RequestResponse:
                case LogTypeEnum.Warning:
                    Console.WriteLine(request.logType.ToString() + " Dosyaya yazıldı");
                    break;
            }
        }
    }

    public class  MailLogger : ILogObserver
    {
        public MailLogger(ILogSubject subject) : base(subject)
        {

        }
        public override void Notify(LogRequest request)
        {
            switch (request.logType)
            {
 
                case LogTypeEnum.Error:
                    Console.WriteLine(request.logType.ToString() + " Mail atıldı");
                    break;
            }
        }
    }

    public class DBLogger : ILogObserver
    {
        public DBLogger(ILogSubject subject) : base(subject)
        {

        }
        public override void Notify(LogRequest request)
        {
            switch (request.logType)
            {
                case LogTypeEnum.Error:
                case LogTypeEnum.RequestResponse:
                    Console.WriteLine(request.logType.ToString() + " DataBase'e yazıldı");
                    break;
            }
        }
    }
}

using System;

namespace ChainOfResponsiblity
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractLogHandler loghandler1 = new MailLogHandler();
            AbstractLogHandler loghandler2 = new DbLogHandler(loghandler1);
            AbstractLogHandler loghandler3 = new FileLogHandler(loghandler2);

            LogRequest request1 = new LogRequest() { Id=1, logType = LogEnumType.RequestResponse };
            LogRequest request2 = new LogRequest() { Id = 2, logType = LogEnumType.Debug };
            LogRequest request3 = new LogRequest() { Id = 3, logType = LogEnumType.Error };
            LogRequest request4 = new LogRequest() { Id = 4, logType = LogEnumType.Warning };
            LogRequest request5 = new LogRequest() { Id = 5, logType = LogEnumType.Info };
            loghandler3.HandleLog(request1);
            loghandler3.HandleLog(request2);
            loghandler3.HandleLog(request3);
            loghandler3.HandleLog(request4);
            loghandler3.HandleLog(request5);

            MiddleWareManager manager = new MiddleWareManager();
            manager.AddMiddleware(new LogMiddleWare())
                .AddMiddleware(new SecurityMiddleWare())
                .AddMiddleware(new TransactionMiddleWare())
                .execute(new MidRequest() { RequestValue = 1 }, new MidResponse());
        }
    }

    public abstract class AbstractLogHandler
    {
        public AbstractLogHandler(AbstractLogHandler next = null)
        {
            this.Next = next;
        }
        public AbstractLogHandler Next { get; set; }
        public abstract void HandleLog(LogRequest request);
    }

    public class FileLogHandler : AbstractLogHandler
    {
        public FileLogHandler(AbstractLogHandler next = null): base(next)
        {

        }

        public override void HandleLog(LogRequest request)
        {
           switch(request.logType)
            {
                case LogEnumType.Debug:
                case LogEnumType.Info:
                case LogEnumType.Warning:
                case LogEnumType.Error:
                    Console.WriteLine(this.ToString() + " Executed for"+" logId:"+request.Id+", logType: " + request.logType.ToString());
                 break;
            }

            if(this.Next!=null)
            {
                this.Next.HandleLog(request);
            }
        }
    }

    public class MailLogHandler : AbstractLogHandler
    {
        public MailLogHandler(AbstractLogHandler next= null) : base(next)
        {

        }

        public override void HandleLog(LogRequest request)
        {
            switch (request.logType)
            {
                case LogEnumType.Error:
                    Console.WriteLine(this.ToString() + " Executed for " + " logId:" + request.Id + ", logType = " + request.logType.ToString());
                    break;
            }

            if (this.Next != null)
            {
                this.Next.HandleLog(request);
            }
        }
    }

    public class DbLogHandler : AbstractLogHandler
    {
        public DbLogHandler(AbstractLogHandler next=null) : base(next)
        {

        }

        public override void HandleLog(LogRequest request)
        {
            switch (request.logType)
            {
                case LogEnumType.Error:
                case LogEnumType.RequestResponse:
                    Console.WriteLine(this.ToString() + " Executed for " + " logId:" + request.Id + ", logType = " + request.logType.ToString());
                    break;
            }

            if (this.Next != null)
            {
                this.Next.HandleLog(request);
            }
        }
    }

    public class LogRequest
    {
        public int Id { get; set; }
        public LogEnumType logType { get; set; }
    }

    public enum LogEnumType
    {
            Info=0,
            Debug,
            Warning,
            Error,
            RequestResponse
    }


   public abstract class IMiddleWare
    {
        public IMiddleWare Next { get; set; }
        public abstract MidResponse Execute(MidRequest request, MidResponse response);
    }

    public class MidRequest
    {
        public int RequestValue { get; set; }
    }

    public class MidResponse
    {
        public int ResponseValue { get; set; }
    }

    public class MiddleWareManager : IMiddleWareManager
    {
        IMiddleWare lastMiddleware;
        IMiddleWare fistmiddleWare;
        public IMiddleWareManager AddMiddleware(IMiddleWare middleWare)
        {
            if(fistmiddleWare == null)
            {
                fistmiddleWare = middleWare;
            }
            else
            {
                lastMiddleware.Next = middleWare;
            }

            lastMiddleware = middleWare;
            return this;
        }

        public void execute(MidRequest request, MidResponse response)
        {
           var result =  fistmiddleWare.Execute(request,response);
        }
    }

    public interface  IMiddleWareManager
    {
        void execute(MidRequest request, MidResponse response);
        IMiddleWareManager AddMiddleware(IMiddleWare middleWare);
    }

    public class LogMiddleWare : IMiddleWare
    {
        public override MidResponse Execute(MidRequest request, MidResponse response)
        {
            ///Loglama yap

            Console.WriteLine("Request Loglandı");
            var result = this.Next.Execute(request, response);
            Console.WriteLine("Response Loglandı");
            return result;
        }
    }

    public class SecurityMiddleWare : IMiddleWare
    {
        public override MidResponse Execute(MidRequest request, MidResponse response)
        {
            ///Güvenlik yap

            Console.WriteLine("Request Güvenlik Kontrolü");
            var result = this.Next.Execute(request, response);
            Console.WriteLine("Response Güvenlik Kontrolü");
            return result;
        }
    }

    public class TransactionMiddleWare : IMiddleWare
    {
        public override MidResponse Execute(MidRequest request, MidResponse response)
        {
            ///Güvenlik yap

            Console.WriteLine("TransactionMiddleWare Başladı");
            ///// Birşeyler yaptı
            Console.WriteLine("TransactionMiddleWare Bitti");
            return new MidResponse() { ResponseValue =1};
        }
    }
}



using System;
using System.Collections.Generic;

namespace ChainofResponsibility2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RequestManager rm = new RequestManager();

            MiddlewareManager mm = new MiddlewareManager();
            mm.AddMiddleWare(new LogMiddleware())
                .AddMiddleWare(new SecurityMiddleware())
            .AddMiddleWare(new TransactionMiddleware());

            rm.middlewareManager = mm;

            rm.Execute(new Request());
            rm.Execute(new Request() { Onaylandi = false});
        }
    }

    public abstract class IMiddleWare
    {
       public IMiddleWare next;

        public abstract void Process(Request request, Response response);

    }

    public class Response
    {
        public string ReturnCode { get; set; }
        public string Message { get; set; }
    }

    public class BadResponse: Response
    {

    }

    public class Request
    {
        public bool Onaylandi = true;
    }

    public class LogMiddleware : IMiddleWare
    {
        public override void Process(Request request, Response response)
        {
            Console.WriteLine("Requesti Logladım");
            if (next != null)
            {
                next.Process(request, response);
                Console.WriteLine("Responsu Logladım");
            }
        }
    }

    public class SecurityMiddleware : IMiddleWare
    {
        public override void Process(Request request, Response response)
        {
            Console.WriteLine("Requesti Güvenlik Kontrollerinden Geçirdim");
            if(!request.Onaylandi)
            {
                response =  new BadResponse();
                return;
            }

            if (next != null)
            {
                next.Process(request, response);
                Console.WriteLine("Responsu Güvenlik Kontrollerinden Geçirdim");
            }
        }
    }

    public class TransactionMiddleware : IMiddleWare
    {
        public override void Process(Request request, Response response)
        {
            Console.WriteLine("Transaction Gerçekleşti");
            response = new Response();
            return;
        }
    }

    public class MiddlewareManager
    {
        List<IMiddleWare> list = new List<IMiddleWare>();

        public MiddlewareManager AddMiddleWare(IMiddleWare item)
        {
            if (list.Count > 0)
            {
                list[list.Count - 1].next = item;
            }

            list.Add(item);

            return this;
        }

        public Response Run(Request request)
        {
            var response = new Response();
            list[0].Process(request, response);
            return response;
        }
    }

    public class RequestManager
    {
        public MiddlewareManager middlewareManager;

        public  Response Execute(Request request)
        {
         return   middlewareManager.Run(request);
        }
    }
}

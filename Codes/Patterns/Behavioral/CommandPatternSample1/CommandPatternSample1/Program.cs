using System;
using System.Collections.Generic;

namespace CommandPatternSample1
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
          Response rs =  user.Process(new Request()
            {
                MethodName = "Topla",
                Value1 = 5,
                Value2 = 7
            });

            rs = user.Process(new Request()
            {
                MethodName = "Cikar",
                Value1 = rs.Result,
                Value2 = 4
            });

            rs = user.Process(new Request()
            {
                MethodName = "Carp",
                Value1 = rs.Result,
                Value2 = 2
            });

            rs = user.Undo(new Request()
            {
                Step = 2
            });


        }
    }

    public class Calculator
    {
        public Response Topla(Request request)
        {
            return new Response()
            {
                Result = request.Value1 + request.Value2
            };
        }

        public Response Cikar(Request request)
        {
            return new Response()
            {
                Result = request.Value1 - request.Value2
            };
        }

        public Response Bol(Request request)
        {
            return new Response()
            {
                Result = request.Value1 / request.Value2
            };
        }

        public Response Carp(Request request)
        {
            return new Response()
            {
                Result = request.Value1 * request.Value2
            };
        }
    }

    public class Response
    {
        public decimal Result;
    }

    public class Request : BaseRequest
    {
        public decimal Value1;

        public decimal Value2;
    }

    public class BaseRequest
    {
        public string MethodName { get; set; }

        public int Step { get; set; } = 1;
    }

       public  interface ICommand
        {
        Response _response { get; set; }
        Response Execute(BaseRequest request);

        Response Undo();

        }

    public class CalculatorCommand : ICommand
    {
        Calculator calculator;
       
        public CalculatorCommand()
        {
            calculator = new Calculator();
        }

        public Response _response { get; set; }

        public Response Execute(BaseRequest request)
        {
            Response response = calculator.GetType().
                  GetMethod(request.MethodName).
                  Invoke(calculator,new object[] { request }) as Response;
            _response = response;
            return response;
        }

        public Response Undo()
        {
            return new Response(); 
        }
    }

    public class User
    {
        List<ICommand> commandList = new List<ICommand>();

        public Response Process(BaseRequest request)
        {
            CalculatorCommand command = new CalculatorCommand();
            commandList.Add(command);
            var response =  command.Execute(request);
            return response;
        }

        public Response Undo(BaseRequest request)
        {
            for (int i = 0; i < request.Step; i++)
            {
                commandList.RemoveAt(commandList.Count - 1);
            }

            return commandList[commandList.Count - 1]._response;
        }
    }


}

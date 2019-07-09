using System;
using System.Collections.Generic;
using System.Linq;
namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CalculatorRequest req1 = new CalculatorRequest() { Value1 = 5, Value2=12,MethodName="Topla" };
            User user = new User();
            CalculatorResponse response1 = user.Compute(req1) as CalculatorResponse;
            CalculatorRequest req2 = new CalculatorRequest() { Value1 = response1.Result, Value2 = 12, MethodName = "Topla" };
            CalculatorResponse response2 = user.Compute(req2) as CalculatorResponse;
            CalculatorRequest req3 = new CalculatorRequest() { Value1 = response2.Result, Value2 = 8, MethodName = "Cıkar" };
            var response3 = user.Compute(req3);
            var response4 = user.Undo();
        }
    }

    public class CalculatorRequest : BaseRequest
    {
        public decimal Value1 { get; set; }
        public decimal Value2 { get; set; }
    }
    public class CalculatorResponse:BaseResponse
    {
        public decimal Result { get; set; }
    }

    public class Calculator : ICalculator
    {
        public CalculatorResponse Bol(CalculatorRequest request)
        {
            return new CalculatorResponse() { Result = request.Value1 / request.Value2 };
        }

        public CalculatorResponse Carp(CalculatorRequest request)
        {
            return new CalculatorResponse() { Result = request.Value1 * request.Value2 };
        }

        public CalculatorResponse Cıkar(CalculatorRequest request)
        {
            return new CalculatorResponse() { Result = request.Value1 - request.Value2 };
        }

        public CalculatorResponse Topla(CalculatorRequest request)
        {
            return  new CalculatorResponse() { Result = request.Value1 + request.Value2 };
        }
    }


    public interface ICalculator
    {
        CalculatorResponse Topla(CalculatorRequest request);
        CalculatorResponse Cıkar(CalculatorRequest request);
        CalculatorResponse Bol(CalculatorRequest request);
        CalculatorResponse Carp(CalculatorRequest request);

    }

    public abstract class ICommand
    {
        public BaseRequest request;
        public ICommand(BaseRequest request)
        {
            this.request = request;
        }
       public abstract BaseResponse Execute();

      public abstract BaseResponse Undo();
    }

   

    public class BaseRequest
    {
        public string MethodName { get; set; }
    }

    public class BaseResponse
    {

    }

    public class CalculatorCommand : ICommand
    {
        ICalculator Calculator;
        public CalculatorCommand(BaseRequest request) : base(request)
        {
            Calculator = new Calculator();
        }

        public override BaseResponse Execute()
        {
            string methodName = request.MethodName;
            var response =   Calculator.GetType().GetMethod(methodName).Invoke(Calculator, new object[] { request });
            return response as BaseResponse;
        }

        public override BaseResponse Undo()
        {
            string methodName = UndoMethod(request.MethodName);
            var response = Calculator.GetType().GetMethod(methodName).Invoke(Calculator, new object[] { request });
            return response as BaseResponse;
        }


        public string UndoMethod(string methodName)
        {
            switch(methodName)
            {
                case "Topla":
                    return "Cıkar";
                case "Cıkar":
                    return "Topla";
                case "Carp":
                    return "Bol";
                case "Bol":
                    return "Carp";
            }

            return methodName;
        }
    }

    public class User
    {
        List<ICommand> commandList;
        public User()
        {
            commandList = new List<ICommand>();
        }

        public BaseResponse Compute(BaseRequest request)
        {
            // Create command operation and execute it
            ICommand command = new CalculatorCommand(request);
            var response = command.Execute();

            // Add command to undo list
            commandList.Add(command);
            return response;
        }

        public BaseResponse Undo(int index = 0)
        {
            if (index == 0)
                index = commandList.Count - 1;

            // Create command operation and execute it
            ICommand command = commandList[index];
            var response = new BaseResponse();
            if (commandList.Count > 1)
            {
                ICommand commandrun = commandList[index-1];
                response = commandrun.Execute();
            }
            // Add command to undo list
            commandList.Remove(command);
            return response;
        }
    }
}

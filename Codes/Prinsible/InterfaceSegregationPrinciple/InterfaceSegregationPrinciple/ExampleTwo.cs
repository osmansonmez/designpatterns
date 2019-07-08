using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationPrinciple2
{
    public interface ITransaction
    {
        void Execute();
    }    

    public interface IReceipt
    {
        void Receipt();
    }

    public class Havale : ITransaction, IReceipt
    {
        public void Execute()
        {
           
        }

        public void Receipt()
        {
           

        }
    }

    public class CreditApplication : ITransaction
    {
        public void Execute()
        {
            Console.WriteLine("Kredi Başvurusu gerçekleşti");
        }
    }
}

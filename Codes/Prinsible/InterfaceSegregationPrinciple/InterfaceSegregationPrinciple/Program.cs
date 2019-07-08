using System;

namespace InterfaceSegregationPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {

            var transaction1 = new InterfaceSegregationPrinciple2.Havale();
            var transaction2= new InterfaceSegregationPrinciple2.CreditApplication();
            transaction1.Execute();
            transaction2.Execute();
            AfterFilter(transaction1);
            AfterFilter(transaction2);

        }

        public static void AfterFilter(InterfaceSegregationPrinciple2.ITransaction transaction)
        {
            if(transaction is InterfaceSegregationPrinciple2.IReceipt)
            {
                ((InterfaceSegregationPrinciple2.IReceipt)transaction).Receipt();
            }
        }

    }

}

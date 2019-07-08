using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationPrinciple1
{
    public interface ITransaction
    {
        void Execute();
        void Receipt();
    }

    public class Havale : ITransaction
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
          
        }

        public void Receipt()
        {
            
        }
    }
}

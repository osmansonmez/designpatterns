using System;
using System.Threading;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {

            SingletonSample sp1 = SingletonSample.Instance;
            Console.WriteLine("Creation Time 1:"+ sp1.CreationTime);
            Thread.Sleep(10000);
            SingletonSample sp2 = SingletonSample.Instance;
            Console.WriteLine("Creation Time 2:"+ sp2.CreationTime);
        }
    }
}

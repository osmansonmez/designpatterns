using System;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //NetworkConnection nc = new
            //    NetworkConnection("192.168.1.1", "5000", 30, "ertert", "ertert");

            //NetworkConnection nc2 =    
            // new NetworkConnectionBuilder()
            //.SetIPPort("192.168.1.1", "5000")
            //.UseSecurity("ertert", "ertert")
            //.UseSSL()
            //.Build();

            NetworkConnection nc2 = new NetworkConnection();
            A a = new A();
            nc2.a = a;

            a.deger = "sdfsdfsd"; 




        }
    }

    public class NetworkConnectionBuilder
    {
         string ip;
         string port;
         int timeout;
         string userName;
         string password;
         bool ssl;
        public A a;
        public NetworkConnectionBuilder SetIPPort(string ip, string port)
        {
            this.ip = ip;
            this.port = port;
            return this;
        }

        public NetworkConnectionBuilder UseSecurity(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            return this;
        }

        public NetworkConnectionBuilder UseSSL()
        {
            this.ssl = true;
            return this;
        }
        public NetworkConnection Build()
        {
            return new NetworkConnection()
            {
                ip = this.ip,
                port = this.port,
                userName = this.userName,
                password = this.password,
                UseSSL = ssl
            };
        }
    }

    public class A
    {
        public string deger = "sdfsdfsdf";
    }

    public class NetworkConnection : ICloneable
    {
        public string ip;
        public string port;
        public int timeout;
        public string userName;
        public string password;
        public bool UseSSL;
        public A a;
        public NetworkConnection()
        {

        }
        public NetworkConnection(string ip, string port)
        {

        }

        public NetworkConnection(string ip, string port, int timeout)
        {

        }

        public NetworkConnection(string ip, string port, int timeout, bool useSSL)
        {

        }

        public NetworkConnection(string ip, string port, int timeout, string userName, string password)
        {

        }

        public object Clone()
        {
          return  this.MemberwiseClone();
        }
    }
}

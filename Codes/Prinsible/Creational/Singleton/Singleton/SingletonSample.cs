using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
   public class SingletonSample
    {
        private static SingletonSample instance;

        private SingletonSample()
        {
            //Bir yerlerden birşeyler getirir. Data gibi
        }
        public static SingletonSample Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonSample();
                    creationTime = DateTime.Now;
                }
                return instance;
            }
        }

        public string CreationTime
        {
            get
            {
                return creationTime.ToString("HH:mm:ss.sss");
            }
        }

        static DateTime creationTime;
    }
}

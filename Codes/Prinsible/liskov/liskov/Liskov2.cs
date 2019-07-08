using System;
using System.Collections.Generic;
using System.Text;

namespace Liskov2
{
    public class Liskov2
    {
        public static void Run()
        {
            List<Kus> suru = new List<Kus>();
            Serce kus1 = new Serce() { isim = "Serçe", yukseklik = 500 };
            Kartal kus2 = new Kartal { isim = "kartal", yukseklik = 1200 };
            Penguen kus3 = new Penguen { isim = "Penguen" };
            suru.Add(kus1);
            suru.Add(kus2);
            //suru.Add(kus3);
            Uc(suru);
        }


    static void Uc(List<Kus> kusSurusu)
    {
        foreach (var item in kusSurusu)
        {
            item.Uc();
        }
    }
}
 
    interface IUcabilirim
    {
        double yukseklik { get; set; }
        void Uc();
    }

    interface IKus
    {
        string isim
        {
            get; set;
        }

        double enlem
        {
            get; set;
        }

        double boylam
        {
            get; set;
        }
    }

    public abstract class Kus: KusBase, IUcabilirim
    {
        double yukseklik_;
        public double yukseklik { get; set; }

        public  void Uc()
        {
            Console.WriteLine(isim + "  " + yukseklik + " metre irtifaya kadar uçar");
            // Go to up to max yukseklik
        }
    }

    public abstract class KusBase : IKus
    {
        public string isim
        {
            get; set;
        }

        public double enlem
        {
            get; set;
        }

        public double boylam
        {
            get; set;
        }
    }

    public class Serce : Kus
    {

    }

    public class Kartal : Kus
    {
    }


    public class Penguen : KusBase
    {

    }
}

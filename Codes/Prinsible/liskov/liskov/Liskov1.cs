using System;
using System.Collections.Generic;
using System.Text;

namespace Liskov1
{
    public class Liskov1
    {
        public static void Run()
        {
            List<Kus> suru = new List<Kus>();
            Serce kus1 = new Serce() { isim = "Serçe", yukseklik = 500 };
            Kartal kus2 = new Kartal { isim = "kartal", yukseklik = 1200 };
            Penguen kus3 = new Penguen { isim = "Penguen" };
            suru.Add(kus1);
            suru.Add(kus2);
            suru.Add(kus3);
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

    public abstract class Kus
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

        public double yukseklik
        {
            get; set;
        }

        public virtual void Uc()
        {
            Console.WriteLine(isim + "  " + yukseklik + " metre irtifaya kadar uçar");
            // Go to up to max yukseklik
        }
    }


    public class Serce : Kus
    {

    }

    public class Kartal : Kus
    {
    }


    public class Penguen : Kus
    {
        public override void Uc()
        {
            throw new Exception("Penguen Uçamaz");
        }
    }
}

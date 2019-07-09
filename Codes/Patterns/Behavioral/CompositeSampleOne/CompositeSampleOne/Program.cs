using System;
using System.Collections.Generic;

namespace CompositeSampleOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Kategori fantastik = new Kategori() { Name = "Fantastik" };
            Kategori bilim = new Kategori() { Name = "Bilim" };
            Kategori bilgisayar = new Kategori() { Name = "Bilgisayar" };

            Kategori yazilim = new Kategori() { Name = "Yazılım" };
            Kategori isletimsistemi = new Kategori() { Name = "isletim sistemi" };
            bilgisayar.Add(yazilim);
            bilgisayar.Add(isletimsistemi);

            Kitap kitap1 = new Kitap() { Name = "Yüzüklerin efendisi" };
            Kitap kitap2 = new Kitap() { Name = "Uzay Yolu" };
            Kitap kitap3 = new Kitap() { Name = "Bilim nedir" };
            Kitap kitap4 = new Kitap() { Name = "Windows" };
            Kitap kitap5 = new Kitap() { Name = "c# ile tanış" };
            Kitap kitap6 = new Kitap() { Name = "Linux" };

            isletimsistemi.Add(kitap4);
            isletimsistemi.Add(kitap6);
            yazilim.Add(kitap5);
            fantastik.Add(kitap1);
            fantastik.Add(kitap3);
            bilim.Add(kitap2);

            Kategori kitaplar = new Kategori() { Name = "Kitaplar" };
            kitaplar.Add(fantastik);
            kitaplar.Add(bilim);
            kitaplar.Add(bilgisayar);


            kitaplar.Display();



        }
    }

    public abstract class IKutuphane
    {
        public string Name { get; set; }

        public virtual void Display(int cizgisayisi = 1)
        {
            string cizgi = new string('-', cizgisayisi);
            Console.WriteLine($"{cizgi} + {Name}");
        }
    }

    public class Kitap : ILeaf
    {

    }

    public class Dergi : ILeaf
    {

    }

    public  class Kategori: IComposite
    {
    }


    public abstract class ILeaf
    {
        public string Name { get; set; }

        public virtual void Display(int cizgisayisi = 1)
        {
            string cizgi = new string('-', cizgisayisi);
            Console.WriteLine($"{cizgi} + {Name}");
        }
    }

    public abstract class IComposite : ILeaf
    {
        List<ILeaf> items = new List<ILeaf>();

        public void Add(ILeaf item)
        {
            items = items ?? new List<ILeaf>();
            items.Add(item);
        }

        public void Remove(ILeaf item)
        {
            items = items ?? new List<ILeaf>();
            items.Remove(item);
        }

        public override void Display(int cizgisayisi = 1)
        {
            string cizgi = new string('-', cizgisayisi++);
            Console.WriteLine($"{cizgi} + {Name} ({items.Count})");

            foreach (var item in items)
            {
                item.Display(cizgisayisi);
            }
        }
    }


}

using System;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Kategori kitaplar = new Kategori() { Name = "Kitaplar" };
            Kategori bilimKurgu = new Kategori() { Name = "Bilim Kurgu" };
            Kategori bilgisayar = new Kategori() { Name = "Bilgisayar" };
            Kategori isletimsistemi = new Kategori() { Name = "İşletim Sistemleri" };
            Kategori yazilim = new Kategori() { Name = "Programlama Dilleri" };

            Kitap kitap1 = new Kitap() { Name = "Uzaylılar dünyada" };
            Kitap kitap2 = new Kitap() { Name = "Marsa Yolculuk" };
            Kitap kitap3 = new Kitap() { Name = "Robotların dansı" };

            Kitap kitap4 = new Kitap() { Name = "c# ile programlama" };
            Kitap kitap5 = new Kitap() { Name = "Linux" };
            Kitap kitap6 = new Kitap() { Name = "Windows" };

            kitaplar.Add(bilimKurgu)
                .Add(bilgisayar);

            bilimKurgu.Add(kitap1)
                .Add(kitap2)
                .Add(kitap3);

            bilgisayar.Add(isletimsistemi)
                .Add(yazilim);

            isletimsistemi.Add(kitap5).Add(kitap6);
            yazilim.Add(kitap6);

            kitaplar.Show();


            KategoriComp books = new KategoriComp() { Name = "Books" };
            KategoriComp bilimKurgucomp= new KategoriComp() { Name = "Bilim Kurgu" };
            KategoriComp bilgisayarcomp = new KategoriComp() { Name = "Bilgisayar" };
            KategoriComp isletimsistemicomp = new KategoriComp() { Name = "İşletim Sistemleri" };
            KategoriComp yazilimcomp = new KategoriComp() { Name = "Programlama Dilleri" };

            books.Add(bilimKurgucomp).Add(bilgisayarcomp);
            bilgisayarcomp.Add(isletimsistemicomp).Add(yazilimcomp);
           

            KitapComp kitap1comp = new KitapComp() { Name = "Uzaylılar dünyada" };
            KitapComp kitap2comp = new KitapComp() { Name = "Marsa Yolculuk" };
            KitapComp kitap3comp = new KitapComp() { Name = "Robotların dansı" };
            bilimKurgucomp.Add(kitap1comp).Add(kitap2comp).Add(kitap3comp);


            KitapComp kitap4comp = new KitapComp() { Name = "c# ile programlama" };
            KitapComp kitap5comp = new KitapComp() { Name = "Linux" };
            KitapComp kitap6comp = new KitapComp() { Name = "Windows" };

            yazilimcomp.Add(kitap4comp);
            isletimsistemicomp.Add(kitap5comp).Add(kitap6comp);
            books.Show();

        }

        public abstract class IKutuphane
        {
            public string Name { get; set; }

            public string Kategori { get; set; }
            public abstract void Show(int karaktersayisi = 1);
        }
        public class Kitap : IKutuphane
        {
            public override void Show(int karaktersayisi = 1)
            {
                string cizgi = new string('-', karaktersayisi);
                Console.WriteLine($"{cizgi} {Name}");
            }
        }

        public class Kategori : IKutuphane
        {
            List<IKutuphane> items = new List<IKutuphane>();

            public Kategori Add(IKutuphane item)
            {
                if (items.Contains(item))
                    return this;
                item.Kategori = this.Name;
                items.Add(item);
                return this;
            }

            public Kategori Remove(IKutuphane item)
            {
                item.Kategori = "";
                items.Remove(item);
                return this;
            }

            public override void Show(int karaktersayisi = 1)
            {
                string cizgi = new string('-', karaktersayisi++);
                Console.WriteLine($"{cizgi} {Name} ({items.Count})");
                foreach (var item in items)
                {
                    item.Show(karaktersayisi);
                }
            }
        }

        public abstract class Item
        {
            public string Name { get; set; }
            public virtual void Show(int count = 1)
            {
                string cizgi = new string('-', count++);
                var header = $"{cizgi} {Name}";
                Console.WriteLine(header);
            }
        }

        public abstract class CompositeItem : Item
        {
            public List<Item> list;

      
            public virtual CompositeItem Add(Item item)
            {
                list = list ?? new List<Item>();
                list.Add(item);
                return this;
            }

            public virtual CompositeItem Remove(CompositeItem item)
            {
                list = list ?? new List<Item>();
                list.Remove(item);
                return this;
            }

            public override void Show(int count = 1)
            {
                string cizgi = new string('-', count++);
                int listcount = list != null ? list.Count : 0;
                var header = listcount > 0 ? $"{cizgi} {Name} ({listcount})" : $"{cizgi} {Name})";
                Console.WriteLine(header);
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        item.Show(count);
                    }
                }
            }
        }

        public class KitapComp : Item
        {
            public string Yazar { get; set; }
        }

        public class KategoriComp : CompositeItem
        {

        }
    }
}

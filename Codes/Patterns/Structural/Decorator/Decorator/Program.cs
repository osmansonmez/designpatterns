using System;
using System.Collections.Generic;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book()
            {
                Name = "Hayallerin Ötesi",
                Author = "Hasan Hüseyin",
                PageSize = 250,
                Count = 38
            };

            Video v1 = new Video() { Name = "Kara Şövalye",
                Count = 23,
                Duration = 58,
                Producer = "Cüneyt Arkın"
            };

            RentableItem rentb = new RentableItem(b1);
            rentb.Rent("Ali Veli");
            rentb.Rent("Ahmet Mehmet");
            rentb.Rent("Kemal");
            rentb.Rent("Emel");
            rentb.Display();

            RentableItem rentv = new RentableItem(v1);
            rentv.Rent("ahmet");
            rentv.Rent("Selim");
            rentv.Rent("Sibel");
            rentv.Display();
        }
    }

    public abstract class Item
    {
        public virtual string Name { get; set; }

        public virtual int Count { get; set; }

        public virtual void Display()
        {
            Console.WriteLine(Name);
        }
    }

    public  class Book: Item
    {
        public string Author { get; set; }

        public int PageSize { get; set; }


        public override void Display()
        {

            Console.WriteLine(Name + "...............");
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("PageSize: " + PageSize);
            Console.WriteLine("Count: " + Count);

        }
    }

    public  class Video : Item
    {
        public string Producer { get; set; }

        public int Duration { get; set; }

        public override void Display()
        {

            Console.WriteLine(Name + "...............");
            Console.WriteLine("Producer: " + Producer);
            Console.WriteLine("Producer: " + Duration);
            Console.WriteLine("Count: " + Count);

        }
    }

    public abstract class ItemDecorator :Item
    {
        protected Item item;
        public ItemDecorator(Item item)
        {
            this.item = item;
        }
    }

    public class RentableItem: ItemDecorator
    {
        public List<string> customers = new List<string>();
        public RentableItem(Item item):base(item)
        {
    
        }

        public void Rent(string customer)
        {
            customers.Add(customer);
            item.Count--;
        }

        public void TakeBack(string customer)
        {
            customers.Remove(customer);
            item.Count++;
        }

        public override void Display()
        {
            Console.WriteLine("Rent Info.............");
            Console.WriteLine("Renters:");
            foreach (var cust in customers)
            {
                Console.WriteLine(cust);
            }

            item.Display();
        }

    }
}

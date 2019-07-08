using System;
using System.Collections.Generic;
using System.Linq;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book() { Author = "Osman", PageSize = 250, Count = 15, Name = "Benim Dünyam" };
            Video v1 = new Video() { Name = "Marsa Yolculuk", Director = "Hasan Ali", Count = 15, Duration = 120 };
            b1.Display();
            v1.Display();

            BorrowableItem item = new BorrowableItem(b1);
            item.BorrowItem("Müşteri 1");
            item.BorrowItem("Müşteri 2");
            item.Display();

            item.ReturnItem("Müşteri 2");
            item.Display();


            RentableItem item2 = new RentableItem(v1);
            item2.RentItem("Müşteri 1",2,2);
            item2.RentItem("Müşteri 2",3,2);
            item2.Display();

            item2.ReturnItem("Müşteri 2");
            item2.Display();

        }
    }

    public abstract class Item
    {
        public int Count { get; set; }

        public abstract void Display();
    }

    public class Video : Item
    {
        public string Name { get; set; }

        public int Duration { get; set; }

        public string Director { get; set; }

        public override void Display()
        {
            Console.WriteLine("Video----------------");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Director: {Director}");
            Console.WriteLine($"Duration: {Duration}");
            Console.WriteLine($"CopyCount: {Count}");
            Console.WriteLine();
        }
    }

    public class Book : Item
    {
        public string Name { get; set; }

        public int PageSize { get; set; }

        public string Author { get; set; }

        public override void Display()
        {
            Console.WriteLine("Book----------------");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"PageSize: {PageSize}");
            Console.WriteLine($"CopyCount: {Count}");
            Console.WriteLine();
        }
    }

    public abstract class DecoratorItem : Item
    {
        protected Item item;

        public DecoratorItem(Item item)
        {
            this.item = item;
        }

        public override void Display()
        {
            item.Display();
        }

    }


    public class BorrowableItem : DecoratorItem
    {
        List<string> borrowers = new List<string>();
        public BorrowableItem(Item item) : base(item)
        {

        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            item.Count--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            item.Count++;
        }

        public override void Display()
        {
            base.Display();
            foreach (string borrower in borrowers)
            {
                Console.WriteLine(" borrower: " + borrower);
            }
            Console.WriteLine("--------------------------------------");
        }
    }

    public class Renter
    {
        public string Name { get; set; }
        public int RentedDays { get; set; }

        public decimal DayPrice { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return DayPrice * RentedDays;
            }
        }
    }
    public class RentableItem : DecoratorItem
    {
        List<Renter> customers = new List<Renter>();
        public RentableItem(Item item) : base(item)
        {

        }

        public void RentItem(string name, decimal price, int day)
        {
            customers.Add(new Renter() { Name = name, DayPrice = price, RentedDays = day });
            item.Count--;
        }

        public void ReturnItem(string name)
        {
            customers.Remove(customers.Find(x => x.Name == name));
            item.Count++;
        }

        public override void Display()
        {
            base.Display();
            foreach (var renter in customers)
            {
                Console.WriteLine(" Renter: " + renter.Name);
                Console.WriteLine(" Price: " + renter.TotalPrice);
                Console.WriteLine(" Days: " + renter.RentedDays);
            }
            Console.WriteLine("--------------------------------------");
        }
    }
}

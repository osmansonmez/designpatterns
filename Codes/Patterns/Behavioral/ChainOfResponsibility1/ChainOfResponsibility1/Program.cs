using System;

namespace ChainOfResponsibility1
{
    class Program
    {
        static void Main(string[] args)
        {
            Personel p1 = new Personel();
            Director d1 = new Director();
            VicePresident v1 = new VicePresident();
            President ps1 = new President();

            p1.next = d1;
            d1.next = v1;
            v1.next = ps1;

            p1.Onayla(new OnayRequest() { Amount = 200000 });
            Console.WriteLine(".............................");
            p1.Onayla(new OnayRequest() { Amount = 20000 });

        }
    }

    public abstract class Onayci
    {
        public Onayci next;
        public abstract void Onayla(OnayRequest request);

    }

    public class OnayRequest
    {
        public decimal Amount { get; set; }
    }

    public class Personel : Onayci
    {
        public override void Onayla(OnayRequest request)
        {
            if(request.Amount<5000)
            {
                Console.WriteLine(this.GetType().Name + "Onayladi");
            }
            else
            {
                Console.WriteLine(next.GetType().Name + " Aktarıldı");
                next.Onayla(request);
            }
        }
    }

    public class Director : Onayci
    {
        public override void Onayla(OnayRequest request)
        {
            if (request.Amount < 20000)
            {
                Console.WriteLine(this.GetType().Name + "Onayladi");
            }
            else
            {
                Console.WriteLine(next.GetType().Name + " Aktarıldı");
                next.Onayla(request);
            }
        }
    }

    public class VicePresident : Onayci
    {
        public override void Onayla(OnayRequest request)
        {
            if (request.Amount < 100000)
            {

                Console.WriteLine(this.GetType().Name + "Onayladi");
            }
            else
            {
                Console.WriteLine(next.GetType().Name + " Aktarıldı");
                next.Onayla(request);
            }
        }
    }

    public class President : Onayci
    {
        public override void Onayla(OnayRequest request)
        {
            if (request.Amount < 500000)
            {
                Console.WriteLine(this.GetType().Name + "Onayladi");
            }
            else
            {
                Console.WriteLine("Yönetim Kuruluna gidecektir");
            }
        }
    }
}

using System;

namespace AbstractFactory3
{
    class Program
    {
        static void Main(string[] args)
        {
            Asya kita1 = new Asya();
            Amerika kita2 = new Amerika();
            CanlilarDunyasi cd1 = new CanlilarDunyasi(kita1);
            cd1.BesinZinciri();

            CanlilarDunyasi cd2 = new CanlilarDunyasi(kita2);
            cd2.BesinZinciri();
        }
    }

    public abstract class Bitki
        {
        public string Name { get; set; }
    }

    public abstract class Hayvan
    {
        public string Name { get; set; }
    }

    public abstract class Etcil:Hayvan
    {
        public virtual void Eat(Otcul besin)
        {
            Console.WriteLine(this.GetType().Name+ $" {besin.GetType().Name}  yer. ");
        }
    }

    public abstract class Otcul:Hayvan
    {
        public virtual void Eat(Bitki besin)
        {
            Console.WriteLine(this.GetType().Name + $" {besin.GetType().Name} yer. ");
        }
    }

    public class Fil : Otcul
    {

    }

    public class Arslan: Etcil
    {

    }

    public class Bison : Otcul
    {

    }

    public class Kurt: Etcil
    {

    }

    public class Ayi : Etcil
    {

    }

    public class Geyik:Otcul
    {

    }

    public class Zurafa : Otcul
    {

    }
    public class Ot:Bitki
    {

    }

    public class Yaprak : Bitki
    {

    }

    public abstract class KitaFabrikasi
    {
        public abstract Etcil GetEtcil();
        public abstract Otcul GetOtcul();
        public abstract Bitki GetBitki();
    }

    public class Asya : KitaFabrikasi
    {
        public override Bitki GetBitki()
        {
            return new Ot();
        }

        public override Etcil GetEtcil()
        {
            return new Kurt();
        }

        public override Otcul GetOtcul()
        {
            return new Fil();
        }
    }

    public class Amerika: KitaFabrikasi
    {
        public override Bitki GetBitki()
        {
            return new Yaprak();
        }

        public override Etcil GetEtcil()
        {
            return new Ayi();
        }

        public override Otcul GetOtcul()
        {
            return new Geyik();
        }
    }

    public class CanlilarDunyasi
    {
        Otcul otcul;
        Etcil etcil;
        Bitki bitki;
        KitaFabrikasi kita;
       public CanlilarDunyasi(KitaFabrikasi kita)
        {
          this.kita = kita;
          bitki =  kita.GetBitki();
          etcil = kita.GetEtcil();
          otcul = kita.GetOtcul();
        }

        public void BesinZinciri()
        {
            Console.WriteLine(kita.GetType().Name + " Besin Zinciri..........");
            otcul.Eat(bitki);
            etcil.Eat(otcul);
        }
    }
}

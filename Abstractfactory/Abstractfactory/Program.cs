using System;

namespace Abstractfactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Besinzinciri bs = new Besinzinciri(new Asya());
            Besinzinciri bs2 = new Besinzinciri(new Amerika());
            bs.Show();

            bs2.Show();
        }

       
       
    }

    public class Besinzinciri
        {

        IKita kita;
        public Besinzinciri(IKita kita)
        {
            this.kita = kita;
        }

        public void Show()
        {
            var etyiyen =  kita.EtYiyen();
            var otyiyen = kita.OtYiyen();
            var bitki = kita.Bitki();
            etyiyen.Eat(otyiyen);
            otyiyen.Eat(bitki);
        }
        }
    public interface IGida
    {

    }

    public abstract class IBitki : IGida
    {

    }
    public abstract class Etcil : IHayvan
    {

    }

    public abstract class IHayvan : IGida
    {
        public virtual void Eat(IGida gida)
        {
            Console.WriteLine(this.GetType().Name + $" { gida.GetType().Name } yedim ");
        }
    }

    public abstract class Otcul :IHayvan
    {

    }

    public class Fil :Otcul
    {

    }

    public class Kurt : Etcil
    {
    }

    public class Aslan : Etcil
    {
    }

    public class Ayi:Etcil
    {

    }

    public class Zurafa : Otcul
    {

    }
    public class Geyik : Otcul
    {

    }

    public class Ot: IBitki
    {

    }

    public class Yaprak : IBitki
    {

    }

    public abstract class IKita
    {
        public abstract IHayvan EtYiyen();
        public abstract IHayvan OtYiyen();
        public abstract IBitki Bitki();
    }

    public class Asya : IKita
    {
        public override IBitki Bitki()
        {
            return new Ot();
        }

        public override IHayvan EtYiyen()
        {
            return new Aslan();
        }

        public override IHayvan OtYiyen()
        {
            return new Fil();
        }
    }

    public class Amerika : IKita
    {
        public override IBitki Bitki()
        {
            return new Yaprak();
        }

        public override IHayvan EtYiyen()
        {
            return new Ayi();
        }

        public override IHayvan OtYiyen()
        {
            return new Geyik();
        }
    }
}

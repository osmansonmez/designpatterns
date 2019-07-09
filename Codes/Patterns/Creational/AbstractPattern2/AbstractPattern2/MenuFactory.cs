using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractPattern2
{
    public abstract class MenuAbstractFactory
    {
        public string Name { get; set; }
        public abstract IYemek GetYemek();

        public abstract IDrink GetIcecek();

    }

    public class Menu1 : MenuAbstractFactory
    {
        public Menu1()
        {
            Name = "Menu1";
        }
        public override IDrink GetIcecek()
        {
            return new Ayran();
        }

        public override IYemek GetYemek()
        {
            return new EtDurum();
        }
    }

    public class Menu2 : MenuAbstractFactory
    {
        public Menu2()
        {
            Name = "Menu2";
        }
        public override IDrink GetIcecek()
        {
            return new Cola();
        }

        public override IYemek GetYemek()
        {
            return new SebzeliPizza();
        }
    }
}

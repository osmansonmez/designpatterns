using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractPattern2
{
    public abstract class  IYemek
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    public class Vejeteryan : IYemek,IVejeteryan
    {

    }

    public class NonVejeteryan : IYemek, INonVejeteryan
    {

    }

    public class SebzeliPizza: Vejeteryan
    {
        public SebzeliPizza()
        {
            Name = "Sebzeli Pizza";
            Price = 25;
        }
    }

    public class EtDurum : NonVejeteryan
    {
        public EtDurum()
        {
            Name = "Et Durum";
            Price = 22;
        }
    }
}

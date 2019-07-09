using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractPattern2
{
    public abstract class IDrink
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    public class Ayran : IDrink
    {
        public Ayran()
        {
            Name = "Ayran";
            Price = 2;
        }
    }

    public class Cola : IDrink
    {
        public Cola()
        {
            Name = "Cola";
            Price = 4;
        }
    }

    public class IceTea : IDrink
    {
        public IceTea()
        {
            Name = "IceTeam";
            Price = 3;
        }
    }
}

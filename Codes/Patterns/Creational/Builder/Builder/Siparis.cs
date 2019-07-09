using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractPattern2
{

    public class Siparis : ISiparis
    {
        List<IDrink> icecekListesi = new List<IDrink>();
        List<IYemek> yemekListesi = new List<IYemek>();
        public void AddIcecek(IDrink icecek)
        {
            icecekListesi.Add(icecek);
        }

        public void AddYemek(IYemek yemek)
        {
            yemekListesi.Add(yemek);
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}

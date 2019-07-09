using System;

namespace AbstractPattern2
{
    class Program
    {
        static void Main(string[] args)
        {

            MenuAbstractFactory menu1 = MenuManager(1);
            PrintMenu(menu1);

            MenuAbstractFactory menu2 = MenuManager(2);
            PrintMenu(menu2);

        }

        public static MenuAbstractFactory MenuManager(int MenuNo)
        {
            switch(MenuNo)
            {
                case 1:
                    return new Menu1();
                case 2:
                    return new Menu2();
                default:
                    return new Menu1();
            }
        }
        public static void PrintMenu(MenuAbstractFactory menu)
        {
            Console.WriteLine("............."+menu.Name+"................");
            var yemek = menu.GetYemek();
            if (yemek is IVejeteryan)
            {
                Console.WriteLine("Vejeterjan Yemek aldınız...");
            }

            Console.WriteLine("Yemek : " + yemek.Name);
            Console.WriteLine("İçecek : " + menu.GetIcecek().Name);

            Console.WriteLine("................................");
        }

    }

}

using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Flyweight.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Flyweight Design Pattern.
    /// </summary>
    public class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Build a document with text
            string document = "AAZZBBZB";
            char[] chars = document.ToCharArray();

            CharacterProcess.CharacterFactory factory = new CharacterProcess.CharacterFactory();
            CharacterProcess.CharacterA A = new CharacterProcess.CharacterA();

            // extrinsic state
            int pointSize = 10;

            // For each character use a flyweight object
            foreach (char c in chars)
            {
                pointSize++;
                CharacterProcess.Character character = factory.GetCharacter(c);
                character.Display(pointSize);
            }

            // Wait for user
            Console.ReadKey();
        }
    }
}

   namespace CharacterProcess
    {
        /// <summary>
        /// The 'FlyweightFactory' class
        /// </summary>
        class CharacterFactory
        {
            private Dictionary<char, Character> _characters =
              new Dictionary<char, Character>();

            public Character GetCharacter(char key)
            {
                // Uses "lazy initialization"
                Character character = null;
                if (_characters.ContainsKey(key))
                {
                    character = _characters[key];
                }
                else
                {
                    switch (key)
                    {
                        case 'A': character = new CharacterA(); break;
                        case 'B': character = new CharacterB(); break;
                        //...
                        case 'Z': character = new CharacterZ(); break;
                    }
                    _characters.Add(key, character);
                }
                return character;
            }
        }

        /// <summary>
        /// The 'Flyweight' abstract class
        /// </summary>
        abstract class Character
        {
            protected char symbol;
            protected int width;
            protected int height;
            protected int ascent;
            protected int descent;
            protected int pointSize;

            public abstract void Display(int pointSize);
        }

        /// <summary>
        /// A 'ConcreteFlyweight' class
        /// </summary>
        class CharacterA : Character
        {
            // Constructor
            internal CharacterA()
            {
                this.symbol = 'A';
                this.height = 100;
                this.width = 120;
                this.ascent = 70;
                this.descent = 0;
            }

            public override void Display(int pointSize)
            {
                this.pointSize = pointSize;
                Console.WriteLine(this.symbol +
                  " (pointsize " + this.pointSize + ")");
            }
        }

        /// <summary>
        /// A 'ConcreteFlyweight' class
        /// </summary>
        class CharacterB : Character
        {
            // Constructor
            public CharacterB()
            {
                this.symbol = 'B';
                this.height = 100;
                this.width = 140;
                this.ascent = 72;
                this.descent = 0;
            }

            public override void Display(int pointSize)
            {
                this.pointSize = pointSize;
                Console.WriteLine(this.symbol +
                  " (pointsize " + this.pointSize + ")");
            }

        }

        // ... C, D, E, etc.

        /// <summary>
        /// A 'ConcreteFlyweight' class
        /// </summary>
        class CharacterZ : Character
        {
            // Constructor
            public CharacterZ()
            {
                this.symbol = 'Z';
                this.height = 100;
                this.width = 100;
                this.ascent = 68;
                this.descent = 0;
            }

            public override void Display(int pointSize)
            {
                this.pointSize = pointSize;
                Console.WriteLine(this.symbol +
                  " (pointsize " + this.pointSize + ")");
            }
        }
    }


using System.Collections.Generic;
using System;


namespace ShoeCloset
{
    class Program
    {
        static ShoeCloset shoeCloset = new ShoeCloset();
        static void Main(string[] args)
        {
            while (true)
            {
                shoeCloset.PrintShoes();
                Console.Write("Press 'a' to add a shoe or 'r' to remove a shoe: ");
                char key = Console.ReadKey().KeyChar;
                switch (key)
                {
                    case 'A':
                    case 'a':
                        shoeCloset.AddShoe();
                        break;
                    case 'r':
                    case 'R':
                        shoeCloset.RemoveShoe();
                        break;
                    default: return;
                }
            }
        }
    }

    class ShoeCloset
    {
        private readonly List<Shoe> shoes = new List<Shoe>();

        public void PrintShoes()
        {
            if (shoes.Count == 0)
            {
                Console.WriteLine("\nThe shoe list is empty");
            } else
            {
                Console.WriteLine("The shoe list contains: ");
                int i = 1;
                foreach (Shoe shoe in shoes)
                {
                    Console.WriteLine($"Shoe #{i++}: {shoe.Description}");
                }
            }
        }

        public void AddShoe()
        {
            Console.WriteLine("\nAdd a shoe");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"Press {i} to add a {(Style)i}");
            }
            Console.Write("Enter a style: ");
            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int style))
            {
                Console.Write("\nEnter the color: ");
                string color = Console.ReadLine();
                Shoe shoe = new Shoe((Style)style, color);
                shoes.Add(shoe);
            }
        }

        public void RemoveShoe()
        {
            Console.Write("\nEnter the numer of the shoe to remove: ");
            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int shoeNumber) && (shoeNumber >= 1) && (shoeNumber <= shoes.Count))
            {
                Console.WriteLine($"\nRemoving {shoes[shoeNumber-1].Description}");
                shoes.RemoveAt(shoeNumber - 1);
            } 
        }

    }

    class Shoe
    {
        public Style Style { get; private set; }
        public string Color { get; private set; }

        public Shoe(Style style, string color)
        {
            Style = style;
            Color = color;
        }

        public string Description
        {
            get { return $"A {Color} {Style}"; }
        }
    }

    enum Style
    {
        Sneaker,
        Loafer,
        Sandal,
        Flipflop,
        Wingtip,
        Clog,
    }
}

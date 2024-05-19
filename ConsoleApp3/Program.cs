using System;
using System.Globalization;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal cat = new Animal();
            cat.SetName("kitty");
            cat.Sound = "Meow";
            Console.WriteLine("The cat is named {0} and says {1}",
                cat.GetName(), cat.Sound);
            cat.Owner = "Krunal";
            Console.WriteLine("{0} owner is {1}",
                cat.GetName(), cat.Owner);
            Console.WriteLine("{0} shelter id is {1}",
                cat.GetName(), cat.idNum);
            Console.WriteLine("# oof Animals is {0}",
                 Animal.NumofAnimals);
        }
    }
}
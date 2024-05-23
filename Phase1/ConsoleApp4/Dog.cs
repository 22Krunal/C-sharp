using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Dog : Animal
    {
        public string Sound2 { get; set; } = "Grrrr";
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound} and {Sound2}");
        }

        public Dog(string name = "No name",
            string sound = "No sound",
            string sound2 = "No Sound2")
            : base(name, sound)
        {
            Sound2 = sound2;
        }
    }
}

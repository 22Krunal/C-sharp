using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Animal
    {
        private string name;
        private string sound;
        public static int numOfAnimals = 0;
        public const string SHELTER = "Home for Animals";
        public readonly int idNum;


        public Animal() : this("No Name", "No Sound") { }
        public Animal(string name): this(name, "No Sound") { }
        public Animal(string name, string sound)
        {
            SetName(name);
            Sound = sound;

            NumofAnimals = 1;
            Random rnd = new Random();
            idNum = rnd.Next(1, 214783640);

        }
        public void MakeSound()
        {
            Console.WriteLine("{0} says {1} ", name, sound);
        }

        public static int GetNumAnimals()
        {
            return numOfAnimals;
        }

        public void SetName(string name)
        {
            if (!name.Any(char.IsDigit))
            {
                this.name = name;
            }
            else
            {
                this.name = "No Name";
                Console.WriteLine("Name can't contain numbers");
            }
        }

        public string GetName()
        {
            return name;
        }
        
        public String Sound
        {
            get { return sound; }
            set
            {
                if(value.Length > 10)
                {
                    sound = "No Sound";
                    Console.WriteLine("Sound is too long");
                }
                else
                {
                    sound = value;
                }
            }
        }
        public string Owner { get; set; } = "No Owner";

        public static int NumofAnimals
        {
            get { return numOfAnimals;  }
            set { numOfAnimals += value; }
        }
    }
}

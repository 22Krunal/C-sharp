using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Animal
    {
        private string name;
        protected string sound;
        
        protected AnimalIDInfo animalIDInfo = new AnimalIDInfo();

        public void SetAnimalIDInfo(int idNum, string owner)
        {
            animalIDInfo.IDNum = idNum;
            animalIDInfo.Owner = owner;
        }
        public void GetAnimalIDInfo()
        {
            Console.WriteLine($"{name} has the ID OF {animalIDInfo.IDNum} and is owned by {animalIDInfo.Owner}");
        }

        public virtual void MakeSound()
        {
            Console.WriteLine($"{name} says {Sound}");
        }
        public Animal() : this("No Name", "No Sound") { }
        public Animal(string name) : this(name, "No Sound") { }
        public Animal(string name, string sound)
        {
            Name = name;
            Sound = sound;
        }

        public String Name
        {
            get { return name; }
            set
            {
                if (value.Any(char.IsDigit))
                {
                    sound = "No Name";
                    Console.WriteLine("Can't use numbers in name");
                }
                else
                {
                    name = value;
                }
            }
        }

        public String Sound
        {
            get { return sound; }
            set
            {
                if (value.Length > 10)
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

        public class AnimalHealth
        {
            public bool HealthyWeight(double height, double weight)
            {
                double calc = height / weight;
                if((calc >= .18) && (calc <= .27))
                {
                    return true;
                }
                return false;
            }
        }
    }
}

 
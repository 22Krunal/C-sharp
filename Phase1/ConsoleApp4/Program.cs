using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            Animal whiskers = new Animal()
            {
                Name = "Whiskers2",
                Sound = "Meow"
            };

            Dog grover = new Dog()
            {
                Name = "Grover",
                Sound = "Woof",
                Sound2 = "Grrrr"
            };

            grover.Sound = "Wooooooof";

            whiskers.MakeSound();
            grover.MakeSound();

            whiskers.SetAnimalIDInfo(1245, "Milind");
            grover.SetAnimalIDInfo(1222, "Krunal");

            whiskers.GetAnimalIDInfo();
            Animal.AnimalHealth getHealth = new Animal.AnimalHealth();

            Console.WriteLine("Is my Animal Healthy: {0}",
                    getHealth.HealthyWeight(11, 46));

            Animal monkey = new Animal()
            {
                Name = "Happy",
                Sound = "Eeeeee"
            };

            Animal spot = new Dog()
            {
                Name = "Spot",
                Sound2 = "YUUUUUU"
            };

            spot.MakeSound();

        }
    }
}
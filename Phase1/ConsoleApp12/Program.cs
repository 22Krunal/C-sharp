using System;
using System.Collections;
using System.Xml.Linq;

namespace ConsoleApp12
{
    public class Program
    {

        static int[] QueryIntArray()
        {
            int[] nums = {5, 10, 15, 20, 25, 30, 35};

            var gt20 = from num in nums
                       where num > 20
                       orderby num
                       select num;

            Console.WriteLine(gt20.GetType().Name);
            foreach(int num in gt20)
            {
                Console.WriteLine(num);
            }

            var arrayGt20 = gt20.ToArray();
            Console.WriteLine("------------------");
            nums[0] = 40;

            foreach (int num in gt20)
            {
                Console.WriteLine(num);
            }

            return arrayGt20;
        }
        static void Main(string[] args)
        {
            string[] dogs = { "K 9", "Brian Griffin", "Scooby Doo", "Snoopy" };

            var dogSpaces = from dog in dogs 
                            where dog.Contains(" ")
                            orderby dog descending
                            select dog;

            foreach(var i in dogSpaces)
            {
                Console.WriteLine(i);
            }
            int[] intArray = QueryIntArray();

            Console.WriteLine("What we got from the fucntion");
            foreach (var i in intArray)
            {
                Console.WriteLine(i);
            }

            ArrayList famAnimals = new ArrayList()
            {
                new Animal{Name = "Heidi",
                Height = 0.8,
                Weight = 18},
                new Animal{Name = "Shrek",
                Height = 4,
                Weight = 138},

                new Animal{Name = "Congo",
                Height = 3.8,
                Weight = 90},
            };

            var famAnimalEnum = famAnimals.OfType<Animal>();

            var smAnimals = from animal in famAnimalEnum
                            where animal.Weight <= 90
                            orderby animal.Name
                            select animal;

            foreach( var animal in smAnimals)
            {
                Console.WriteLine(animal);
            }

            Animal[] animals = new[]
            {
                new Animal{Name = "German Shephard",
                Height = 25,
                Weight = 77,
                AnimalID = 1},

                new Animal{Name = "Chihuahua",
                Height = 7,
                Weight = 4.4,
                AnimalID = 2},

                new Animal{Name = "Saint Bernard",
                Height = 30,
                Weight = 200,
                AnimalID = 3},

                new Animal{Name = "Pug",
                Height = 12,
                Weight = 6,
                AnimalID = 1},

                new Animal{Name = "Beagle",
                Height = 15,
                Weight = 23,
                AnimalID = 2}
            };

            Owner[] owners = new[]
            {
                new Owner{Name = "Doug Parks",
                OwnerID = 1},
                new Owner{Name = "Sally Smith",
                OwnerID = 2},
                new Owner{Name = "Paul Brooks",
                OwnerID = 3}
            };

            var animalListEnum = animals.OfType<Animal>();


            var bigDogs = from dog in animalListEnum
                          where (dog.Weight > 70) &&
                          (dog.Height > 25)
                          orderby dog.Name
                          select dog;

            foreach(var animal in bigDogs)
            {
                Console.WriteLine(animal);
            }

            var nameHeight = from a in animals
                             select  new
                             {
                                 a.Name,
                                 a.Height
                             };

            Array arrNameHeight = nameHeight.ToArray();

            foreach(var i in arrNameHeight)
            {
                Console.WriteLine(i.ToString());
            }

            var innerJoin = from animal in animals
                            join owner in owners on animal.AnimalID
                            equals owner.OwnerID
                            select new
                            {
                                OwnerName = owner.Name,
                                AnimalName = animal.Name
                            };

            foreach(var i in innerJoin)
            {
                Console.WriteLine("{0} owns {1}",
                    i.OwnerName, i.AnimalName);
            }

            var groupJoin = from owner in owners
                            orderby owner.OwnerID
                            join animal in animals on owner.OwnerID
                            equals animal.AnimalID into ownerGroup
                            select new
                            {
                                 Owner = owner.Name,
                                 Animals = from owner2 in ownerGroup
                                           orderby owner2.Name
                                           select owner2
                            };

            foreach(var k in groupJoin)
            {
                Console.WriteLine($"{k.Owner} owns");
                Console.WriteLine("-----------------------");
                foreach(var j in k.Animals)
                {
                    Console.WriteLine(j.Name);
                }
                Console.WriteLine("-----------------------");
            }
        }
    }
}
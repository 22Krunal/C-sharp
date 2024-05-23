using System;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animalList = new List<Animal>();

            List<int> numList = new List<int>();
            numList.Add(18);


            animalList.Add(new Animal() { Name = "Doug" });
            animalList.Add(new Animal() { Name = "Paul" });
            animalList.Add(new Animal() { Name = "Sally" });

            animalList.Insert(1, new Animal() { Name = "Steve Rogers" });

            //animalList.RemoveAt(1);

            Console.WriteLine("Num of Animals : {0}", animalList.Count());

            foreach(Animal animal in animalList)
            {
                Console.WriteLine(animal.Name);
            }

            int x = 5, y = 13;

            Animal.GetSum<int>(ref x, ref y);

            string strx = "6", stry = "12";

            Animal.GetSum<string>(ref strx, ref stry);


            Rectangle<int> rec1 = new Rectangle<int>(20, 50);

            Console.WriteLine(rec1.GetArea());

            Rectangle<string> rec2 = new Rectangle<string>("30", "40");
            Console.WriteLine(rec2.GetArea());


            Arithmetic add, sub, addSub;

            add = new Arithmetic(Add);
            sub = new Arithmetic(Substract);
            addSub = add + sub + add;

            Console.WriteLine($"Add {6} & {10}");
            add(6, 10);
            Console.WriteLine($"Add & Substract {10} & {4}");
            addSub(10, 4);

        }

        public struct Rectangle<T>
        {
            private T width;
            private T length;

            public T Width
            {
                get { return width; }
                set { width = value; }
            }

            public T Length
            {
                get { return length; }
                set { length = value; }
            }

            public Rectangle(T w, T l)
            {
                width = w;
                length = l;
            }

            public double GetArea()
            {
                double dblW = Convert.ToDouble(Width);
                double dblL = Convert.ToDouble(Length);

                return dblW * dblL;

            }
        }

        public delegate void Arithmetic(double num1, double num2);

        public static void Add(double num1, double num2)
        {
            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
        }

        public static void Substract(double num1, double num2)
        {
            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
        }
    }
}
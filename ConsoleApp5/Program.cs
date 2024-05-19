using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Cricle c1 = new Cricle(10);
            c1.GetInfo();
            Console.WriteLine("Area of circle is : {0}", c1.Area());

            Rectangle r1 = new Rectangle(10, 15);
            r1.GetInfo();
            Console.WriteLine("Area of Rectangle is : {0}", r1.Area());

            Console.WriteLine("--------------------------------------");
            Shape[] shapes = { new Cricle(5), new Rectangle(4, 5) };

            foreach(var  shape in shapes)
            {
                shape.GetInfo();
                Console.WriteLine("Area of {1} is : {0}", shape.Area(), shape.Name);

                Cricle testCric = shape as Cricle;

                if(testCric == null)
                {
                    Console.WriteLine("This isn't a Cricle");
                }
                if (shape is Cricle)
                {
                    Console.WriteLine("This isn't a Rectangle");
                }
            }

            object cric1 = new Cricle(4);

            Cricle cric2 = (Cricle)cric1;

            Console.WriteLine("This {0} Area is {1:f2}",
                cric2.Name, cric2.Area());
        }
    }
}
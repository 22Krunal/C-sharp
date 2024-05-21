using System;

namespace ConsoleApp10
{
    public class Program
    {
        delegate double doubleIt(double val);
        static void Main(string[] args)
        {
            doubleIt dblIt = x => x * 2;
            Console.WriteLine(dblIt(6));

            List<int> numList = new List<int> { 1, 9, 2, 6, 3};

            var evenList = numList.Where(a => a % 2 == 0).ToList();

            foreach (var j in evenList) Console.WriteLine(j);

            var rangeList = numList.Where(x => (x > 2) || (x < 9)).ToList();
            foreach (var j in rangeList) Console.WriteLine(j);


            List<int> flipList = new List<int>();
            int i = 0;
            Random rnd = new Random();
            while(i < 100)
            {
                flipList.Add(rnd.Next(1, 3));
                i++;
            }

            Console.WriteLine("Heads : {0}",
                flipList.Where(a => a == 1).ToList().Count);
            Console.WriteLine("Tails : {0}",
                flipList.Where(a => a == 2).ToList().Count);


            var nameList = new List<String> { "Virat", "Jordan", "Ronaldo", "Viswanth" };

            var sName = nameList.Where(x => x.StartsWith("V"));

            foreach(var m in sName) Console.WriteLine(m);

            var oneToTen = new List<int>();

            oneToTen.AddRange(Enumerable.Range(1, 10));

            var squares = oneToTen.Select(x => x * x);

            foreach(var l in squares) Console.WriteLine(l);


            Console.WriteLine("---------------------------");

            var listOne = new List<int>( new int[] { 1, 3, 4 } );
            var listTwo = new List<int>( new int[] { 4, 6, 8 } );

            var sumList = listOne.Zip(listTwo, (x, y) => x + y).ToList();

            foreach(var sum in sumList) Console.WriteLine(sum);

            Console.WriteLine("Sum: {0}",
                sumList.Aggregate((a, b) => a + b));
        }
    }
}
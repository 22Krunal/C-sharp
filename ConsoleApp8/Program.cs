using System;
using System.Globalization;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ArrayList Code

            ArrayList alist = new ArrayList();
            alist.Add("Bob");
            alist.Add(40);

            Console.WriteLine("Count : {0}", alist.Count);
            Console.WriteLine("Capacity : {0}", alist.Capacity);

            ArrayList alist2 = new ArrayList();
            alist2.AddRange(new object[] { "Krunal", "Deep", "Milind" });
            alist.AddRange(alist2);

            alist2.Sort();
            alist2.Reverse();

            alist.Insert(2, "India");
            alist2.RemoveAt(0);

            alist.RemoveRange(0, 2);

            Console.WriteLine("India index : {0} ", alist.IndexOf("India",0));

            foreach(object o in alist)
            {
                Console.WriteLine(o);
            }

            string[] myArray = (string[])alist.ToArray(typeof(string));

            string[] customers = { "Virat", "Jordan", "Ronaldo" };
            ArrayList custArrayList = new ArrayList();
            
            custArrayList.AddRange(customers);

            #endregion

            Console.WriteLine("------------------");

            #region Dictionary Code
            Dictionary<string, string> superherors = new Dictionary<string, string>();
            superherors.Add("Clark Kent", "Superman");
            superherors.Add("Bruce Wayne", "Batman");
            superherors.Add("Virat Kohli", "King");
            superherors.Add("Michle Jordan", "Blck Jesus");

            Console.WriteLine("Count : {0}", superherors.Count);
            Console.WriteLine("Virat Kohli : {0}", superherors.ContainsKey("Virat Kohli"));

            superherors.TryGetValue("Virat Kohli", out string test);
            Console.WriteLine($"Virat Kohli :{test}");

            foreach(KeyValuePair<string, string> superhero in superherors)
            {
                Console.WriteLine("{0} : {1}", superhero.Key, superhero.Value);
            }
            #endregion

            Console.WriteLine("------------------");

            #region Queue Code
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine("1 in Queue: {0} ", queue.Contains(1));
            Console.WriteLine("Remove : {0} ", queue.Dequeue());
            Console.WriteLine("1 in Queue: {0} ", queue.Peek());

            object[] numArray = queue.ToArray();
            Console.WriteLine(String.Join(",", numArray));
            
            foreach(object o in queue)
            {
                Console.WriteLine("Queue: {0}", o);
            }

            queue.Clear();
            #endregion

            Console.WriteLine("------------------");

            #region Stack Code
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine("1 in Stack: {0} ", stack.Contains(1));
            Console.WriteLine("Remove : {0} ", stack.Pop());
            Console.WriteLine("1 in Stack: {0} ", stack.Peek());

            object[] numArray1 = stack.ToArray();
            Console.WriteLine(String.Join(",", numArray1));

            foreach (object o in stack)
            {
                Console.WriteLine("Stack: {0}", o);
            }

            stack.Clear();
            #endregion
        }
    }
}
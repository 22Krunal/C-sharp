using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*  type converstions
            bool canIVote = bool.Parse("TRue");
            string x = "Hello";
            x.ToUpper();
            Console.WriteLine(double.Parse("1000"));
            Console.WriteLine((100.ToString()).GetType());


            Console.WriteLine((int)100.1234);    // explicit converstion (big(double) to small(int)) 
            Console.WriteLine((double)100);      // implicit converstion (small (int) to big (double))
            Console.ReadLine();
            return;

            */

            /* different datatypes and max/min values
             
            bool canIVote = false;
            Console.WriteLine("Max Integer :{0}", int.MaxValue);
            Console.WriteLine("Min Integer :{0}", int.MinValue);

            Console.WriteLine("Max Long :{0}", long.MaxValue);
            Console.WriteLine("Min Long :{0}", long.MinValue);

            Console.WriteLine("Max Decimal :{0}", decimal.MaxValue);
            Console.WriteLine("Min Decimal :{0}", decimal.MinValue);

            Console.WriteLine("Max Double :{0}", double.MaxValue);
            Console.WriteLine("Min Double :{0}", double.MinValue);
            */



            /* string operations
             
            // Strings store a series of characters
            string randString = "This is a string";
            //***String Formatting with Placeholders**

            //In C#, you can use placeholders in a format string to insert values dynamically at runtime.
            //The placeholders are enclosed in curly braces {} and are indexed starting from 0.
            //The index inside the curly braces corresponds to the position of the argument in the parameter list.

            //Example Explained
            Console.WriteLine("String Contains is : {0}", randString.Contains("is"));
            
            

            Console.WriteLine("String Length : {0}", randString.Length);


            //The Contains method checks if a specified substring exists within the string.
            Console.WriteLine("String Contains is : {0}",
                randString.Contains("is"));


            Console.WriteLine("Index of is : {0}",
                randString.IndexOf("is"));

            // Remove number of characters starting at an index
            Console.WriteLine("Remove string : {0}",
                randString.Remove(10, 6));

            // Add a string starting at an index
            Console.WriteLine("Insert String : {0}",
                randString.Insert(10, "short "));

            // Replace a string 
            Console.WriteLine("Replace String : {0}",
                randString.Replace("string", "sentence"));



            Console.WriteLine("Compare A to B : {0}",
                String.Compare("A", "B", StringComparison.OrdinalIgnoreCase));

            // Check if strings are equal
            Console.WriteLine("A = a : {0}",
                String.Equals("A", "a", StringComparison.OrdinalIgnoreCase));

            // Add padding left
            Console.WriteLine("Pad Left : {0} ",
                randString.PadLeft(20, '.'));

            // Add padding right
            Console.WriteLine("Pad Right : {0} HIIIIIII",
                randString.PadRight(20, '.'));

            // Trim whitespace
            Console.WriteLine("Trim : {0}",
                randString.Trim());

            //  uppercase
            Console.WriteLine("Uppercase : {0}",
                randString.ToUpper());

            // lowercase
            Console.WriteLine("Lowercase : {0}",
                randString.ToLower());

            // Use Format to create strings
            string newString = String.Format("{0} saw a {1} {2} in the {3}",
                "Paul", "rabbit", "eating", "field");

            //  add newlines with \n and join strings with +
            Console.Write(newString + "\n");

            Console.WriteLine(@"Exactly What I Typed\n");
            
            */
            
            
            /* input / output 
             
            Console.Write("Enter your good name :: ");
            string fname = Console.ReadLine();
            string lname = Console.ReadLine();
            Console.WriteLine($"hello {fname} {lname}");
            */

        }
    }
}
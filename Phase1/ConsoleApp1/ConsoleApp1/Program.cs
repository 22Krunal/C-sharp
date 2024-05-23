using System;
using System.Collections.Immutable;
using System.Text;

namespace ConsoleApp1
{
    public class Program
    {
        //----- FUNCTIONS START -----//
        static void printArray(int[] array)
        {
            foreach(var k in array)
            {
                Console.Write("{0} ", k);
            }
            Console.WriteLine();
            Console.WriteLine("--------------");
        }

        static double DoDivision(double num1, double num2)
        {
            if(num2 == 0)
            {
                throw new System.DivideByZeroException();
            }
            return num1 / num2;
        }

        private static void SayHello()
        {
            Console.Write("What is your name? :");
            String name = Console.ReadLine();
            Console.WriteLine($"Hello {name}, Welcome to C# learning sessions");
        }

        static double GetSum(double x = 0, double y = 0)
        {
            return x + y;
        }

        static void DoubleIt(int x , out int solution)
        {
            solution = x * 2;
        }
        
        static void SwapNum(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
            return;
        }

        static double GetSumMore(params double[] nums)
        {
            double sum = 0;
            foreach(double num in nums)
            {
                sum += num;
            }
            return sum;
        }

        static void PrintInfo(string name, int age)
        {
            Console.WriteLine($"My name is {name}. I am {age} years old");
        }

        // --- METHOD OVERLOADING --- //
        static double GetSum2(double x=0, double y = 0)
        {
            return x + y;
        }
        static double GetSum2(double x=0, double y=0, double z = 0)
        {
            return x + y + z;
        }
        static double GetSum2(string x = "0", string y = "0")
        {
            return Convert.ToDouble(x) + Convert.ToDouble(y);
        }
        // -------------------------- //

        static  void PaintCar(CarColor cc)
        {
            Console.WriteLine("The car was painted {0} with the code {1}", 
                cc, (int)cc);
        }
        //----- FUNCTIONS END -----//

        enum CarColor : byte
        {
            Orange = 1,
            Blue,
            Green,
            Red,
            Yellow
        }
        static void Main(string[] args)
        {
            CarColor car1 = CarColor.Green;
            PaintCar(car1);
            Console.ReadLine();
            

            
            /*-------DATE AND TIME---------
            
            DateTime awesomeDate = new DateTime(2002, 2, 22);
            Console.WriteLine("Day of the week : {0} ", awesomeDate.DayOfWeek);
            awesomeDate = awesomeDate.AddYears(1);
            Console.WriteLine("Day of the week : {0} ", awesomeDate);

            TimeSpan lunchTime = new TimeSpan(12, 30, 0);
            lunchTime = lunchTime.Subtract(new TimeSpan(0, 15, 0));

            Console.WriteLine(lunchTime.ToString());

             ------------------------------*/
            
            
            /*------ FUNCTIONS -----
            int solution;
            DoubleIt(15, out solution);
            Console.WriteLine(solution);
            int x = 5, y = 10;
            SwapNum(ref x, ref y);
            Console.WriteLine($"{x} ,{y}");
            // out and ref treated same at compile time and different at run 
            // time , we use ref when changes should be reflected and out 
            // when we have to return more than one value
            
            Console.WriteLine($"This is the sum {GetSumMore(1, 2, 3, 4)} ");
            //Console.WriteLine(GetSum(4, 5));
            //SayHello();

            PrintInfo(age: 23, name: "Krunal");  //named params so can pass it in any order


            Console.WriteLine("ANS FROM METHOD OVERLOADIN : {0} AND {1}", GetSum2(x, y), GetSum2(x.ToString(), y.ToString()));
            Console.WriteLine(GetSum2(2, 4, 0));
            
            ------------------------*/


            /*--------------------STRING BUILDERS-----------
             *
            // add space automatically, by default has 16 char space 
            // can change char directly into the memory rather than creating new copy
            StringBuilder sb = new StringBuilder("My name is Krunal");
            StringBuilder sb2 = new StringBuilder("I am ICT Student", 20);   // giving the fixed size for string
            Console.WriteLine($"This is my first string {sb}, and this is the type of it {sb.GetType().Name}, length of the string is {sb.Length}");
            Console.WriteLine($"This is my first string {sb.Capacity}, and this is the type of it {sb2.GetType().Name}, length of the string is {sb2.Length}");
            
             -----------------------------------------------*/
            
            /* ------------EXCEPTIONAL HANDLING-------------
             
            double num1 = -4, num2 = 0;
            try
            {
                Console.WriteLine("{0} / {1} = {2}", num1, num2, DoDivision(num1, num2));
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("you can't divide by zero!!!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType().Name);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Occured!!!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType().Name);
            }
            finally               // --- every time this block will run in both try and catch so can used as clean up block
            {
                Console.WriteLine("Cleaning up!!!");
            }

            -------------------------------------------------- */

            /*
            // To compare strings use Equals
            string name2 = "Derek";
            string name3 = "Derek";

            if (name2.Equals(name3, StringComparison.Ordinal))
            {
                Console.WriteLine("Names are Equal");
            }

            // ----- WHILE LOOP -----
            // You use the while loop when you want to execute
            // as long as a condition is true

            // This while loop will print odd numbers between
            // 1 and 10
            int i = 1;
            while (i <= 10)
            {
                // % (Modulus) returns the remainder of a
                // division. If it returns 0 that means the
                // value is even
                if (i % 2 == 0)
                {
                    i++;

                    // Continue skips the rest of the code and
                    // starts execution back at the top of the
                    // while
                    continue;
                }

                // Break jumps completely out of the loop
                if (i == 9) break;

                Console.WriteLine(i);
                i++;
            }
             */

            /* DO WHILE LOOP
            // Use do while when you must execute the code
            // at least once

            // Generate a random number
            Random rnd = new Random();
            int secretNumber = rnd.Next(1, 11);
            int numberGuessed = 0;
            Console.WriteLine("Random Num : ", secretNumber);

            do
            {
                Console.Write("Enter a number between 1 & 10 : ");

                // Use Convert to switch the string into an int
                // Other Convert options : ToBoolean, ToByte,
                // ToChar, ToDecimal, ToDouble, ToInt64,
                // ToString, and they can convert from any
                // type to any other type
                numberGuessed = Convert.ToInt32(Console.ReadLine());

            } while (secretNumber != numberGuessed);

            Console.WriteLine("You guessed it is was {0}",
                secretNumber);
              */
            

            /* Operators 
             

            // Relational Operators : > < >= <= == !=
            // Logical Operators : && || !

            int age = 17;

            if ((age >= 5) && (age <= 7))
            {
                Console.WriteLine("Go to elementary school");
            }
            else if ((age > 7) && (age < 13))
            {
                Console.WriteLine("Go to middle school");
            }
            else if ((age > 13) && (age < 19))
            {
                Console.WriteLine("Go to high school");
            }
            else
            {
                Console.WriteLine("Go to college");
            }

            if ((age < 14) || (age > 67))
            {
                Console.WriteLine("You shouldn't work");
            }

            Console.WriteLine("! true = " + (!true));

            // Ternary Operator
            // Assigns the 1st value if true and otherwise
            // the 2nd
            bool canDrive = age >= 16 ? true : false;

            // Switch is used when you have limited options
            // The only way to use ranges is to stack
            // the possible values
            switch (age)
            {
                case 1:
                case 2:
                    Console.WriteLine("Go to Day Care");
                    break;
                case 3:
                case 4:
                    Console.WriteLine("Go to Preschool");
                    break;
                case 5:
                    Console.WriteLine("Go to Kindergarten");
                    break;
                default:
                    Console.WriteLine("Go to another school");
                    // You can also jump out of a switch
                    // with goto
                    goto OtherSchool;
            }

        OtherSchool:
            Console.WriteLine("Elementary, Middle, High School");
             
             */


            /*Array operations 
             
            int[] Array = new int[4];
            for(int i=0; i<Array.Length; i++)
            {
                //Array[i] = int.Parse(Console.ReadLine());
                string ans = Console.ReadLine();
                Array[i] = int.Parse(ans);
            }
            printArray(Array);
            string[] strArray = { "Krunal", "Patel" };
            var newArray = new[] { 1, 2, 4, 3 };
            object[] obj = { "krunal", 1, 12.4 };

            for(int i=0; i<strArray.Length; i++)
            {
                Console.WriteLine("{0} -> {1} ", i, strArray[i]);
            }
            Console.WriteLine("----------------");

            foreach(var k in obj)
            {
                Console.WriteLine("{0}  ", k);
            }
            Console.WriteLine("----------------");
            //Array.Reverse(Array);
            printArray(Array);
            Console.ReadLine();
            // foreach can be used to cycle through an array
            int[] randNums = { 1, 4, 9, 2 };

            // You can pass an array to a function
            PrintArray(randNums);

            // Sort array
            Array.Sort(randNums);

            // Reverse array
            Array.Reverse(randNums);

            // Get index of match or return -1
            Console.WriteLine("1 at index : {0} ",
                Array.IndexOf(randNums, 1));

            // Change value at index 1 to 0
            randNums.SetValue(0, 1);

            // Copy part of an array to another
            int[] srcArray = { 1, 2, 3 };
            int[] destArray = new int[2];
            int startInd = 0;
            int length = 2;

            Array.Copy(srcArray, startInd, destArray,
                startInd, length);

            PrintArray(destArray);

            // Create an array with CreateInstance
            Array anotherArray = Array.CreateInstance(typeof(int), 10);

            // Copy values in srcArray to destArray starting
            // at index 5 in destination
            srcArray.CopyTo(anotherArray, 5);

            foreach (int m in anotherArray)
            {
                Console.WriteLine("CopyTo : {0} ", m);
            }
             */

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
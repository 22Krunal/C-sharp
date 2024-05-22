using System;

namespace ConsoleApp13
{
    public class Program
    {

        static void Print1()
        {
            for(int i=0; i<1000; i++)
            {
                Console.Write(1);
            }
        }

        static void Main(string[] args)
        {
            BankAcct acct = new BankAcct(10);

            Thread[] threads = new Thread[15];

            Thread.CurrentThread.Name = "main";

            for(int i=0; i<15; i++)
            {
                Thread t = new Thread(new ThreadStart(acct.IssuWithdraw));

                t.Name = i.ToString();

                threads[i] = t;
            }

            for(int i=0; i<15; i++)
            {
                Console.WriteLine("Thread {0} alive : {1}",
                    threads[i].Name, threads[i].IsAlive);
                
                threads[i].Start();

                Console.WriteLine("Thread {0} alive : {1}",
                    threads[i].Name, threads[i].IsAlive);
            }

            Console.WriteLine("Current Priority : {0}",
                Thread.CurrentThread.Priority);

            Console.WriteLine("Thread {0} ending : {1}",
                Thread.CurrentThread.Name, Thread.CurrentThread.Name);

            /*Bank transction example
             
             */
            /*
             * Basic Thread examples
            
            int num = 1;
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(num);
                Thread.Sleep(1000);
                num++;
            }
            Console.WriteLine("Thread Ends...");

            Thread t = new Thread(Print1);
            t.Start();

            for (int i = 0; i < 1000; i++)
            {
                Console.Write(0);
            }
             */
        }
    }
}
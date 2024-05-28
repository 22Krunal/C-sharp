using System;
using System.IO;

namespace Delegates
{

    public class Program
    {
        delegate void LogDel(string message);
        static void Main(string[] args)
        {
            Log log = new Log();
            LogDel logDel = new LogDel(log.LogTextToScreen);
            logDel += log.LogTextToFile;

            LogDel logDel1 = new LogDel(log.LogTextToScreen);
            LogDel logDel2 = new LogDel(log.LogTextToFile);
             
            LogDel del = logDel1 + logDel2;

            del("Multicaste Delegate");
            LogText(logDel, "Hy I am from function passed with delegate as an argument");
            logDel("Hello From Delegate File");
            Console.WriteLine("Hello World");
        }
         static void LogText(LogDel logDel, string message)
        {
            logDel(message);
        }
    }

    public class Log
    {
        public void LogTextToScreen(string message)
        {
            Console.WriteLine(message);
        }

        public void LogTextToFile(string message)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Krunal.txt"), true))
            {
                sw.WriteLine($"{message}");
            }
        }

    }
}
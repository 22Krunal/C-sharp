using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {

            /*--------------Vehicle with drivable interface-------------/ 
            ------------------------------------------------------------*/
            IElectronicDevice TV = TVRemote.GetDevice();
            PowerButton powBut = new PowerButton(TV);

            powBut.Execute();
            powBut.Undo();

            //abstract - we have atleast one abstract method
            // interface - have to implement all in the derived class


            /*--------------Vehicle with drivable interface-------------/ 
             
            Console.WriteLine("Hello World");
            Vehicle buick = new Vehicle("Buick", 4, 160);


            if(buick is IDrivable)
            {
                buick.Move();
                buick.Stop();
            }
            else
            {
                Console.WriteLine("The {0} can't be driven", buick.Brand);
            }
            -------------------------------------------------------------*/
        }
    }
}
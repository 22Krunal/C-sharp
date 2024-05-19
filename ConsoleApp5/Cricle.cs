using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Cricle : Shape 
    {
        public double Radius { get; set; }

        public Cricle(double r)
        {
            Name = "Cricle";
            Radius = r;
        }

        
        public override double Area()
        {
            return Math.PI * (Math.Pow(Radius, 2.0));
        }
        
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"It has a Radius of {Radius}");
        }
         

    }
}

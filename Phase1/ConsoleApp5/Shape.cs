using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    // never gonna make instance of this class that's why abstract
    abstract class Shape
    {
        
        public string Name { get; set; }
        
        /*
         -Main difference between abstract and virtual is that
          you have to define abstract methods in inherited(child/sub) 
          classes and you may or may not define virtual function
         */
        public virtual void GetInfo()
        {
            Console.WriteLine("This is a {0}", Name);
        }

        public abstract double Area();
    }
}

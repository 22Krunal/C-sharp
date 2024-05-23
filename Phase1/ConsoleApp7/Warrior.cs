using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Warrior
    {
        public string Name { get; set;}

        public double Health { get; set;}

        public double AttakMax { get; set;}
        public double BlockMax { get; set; }

        Random rnd = new Random();

        public Warrior(string name = "Warrior", 
            double health = 0,
            double attackMax = 0,
            double blockMax = 0)
        {
            Name = name;
            Health = health;
            AttakMax = attackMax;
            BlockMax = blockMax;
        }

        public virtual double Attack()
        {
            return rnd.Next(1, (int)AttakMax);
        }
        public virtual double Block()
        {
            return rnd.Next(1, (int)BlockMax);
        }
    }
}

using System;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior Thor = new Warrior("Thor", 100, 26, 10);
            MagicWarrior Loki = new MagicWarrior("Loki", 75, 20, 10, 50);

            Battle.StartFight(Thor, Loki);
        }
    }
}
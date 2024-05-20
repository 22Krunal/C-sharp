using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Battle
    {
        //start the fight
        // war1 attacks war2, war2 is damged and health is decreased
        // Get attak result
        // war2 attacks war1, war1 is damged and health is decreased
        // Get attak result


        public static void StartFight(Warrior warrior1, Warrior warrior2)
        {
            while (true)
            {
                if (GetAttackResult(warrior1, warrior2) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    return;
                }
                if (GetAttackResult(warrior2, warrior1) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    return;
                }
            }
            
        }

        //Get Attack Result

        public static String GetAttackResult(Warrior warriorA, Warrior warriorB)
        {
            double warAAttAmt = warriorA.Attack();
            double warBBlkAmt = warriorB.Block();

            double dmg2WarB = warAAttAmt - warBBlkAmt;

            if(dmg2WarB > 0)
            {
                warriorB.Health = warriorB.Health - dmg2WarB;
            }
            else
            {
                dmg2WarB = 0;
            }

            Console.WriteLine("{0} Attacks {1} and Deals {2} Damage",
                warriorA.Name,
                warriorB.Name,
                dmg2WarB);
            Console.WriteLine("{0} Has {1} Health\n",
                warriorB.Name,
                warriorB.Health);

            if(warriorB.Health <= 0)
            {
                Console.WriteLine("{0} has Died and {1} is Victorious\n",
                warriorB.Name,
                warriorA.Name);

                return "Game Over";
            }
            else
            {
                return "Fight Again";
            }

        }
    }
}

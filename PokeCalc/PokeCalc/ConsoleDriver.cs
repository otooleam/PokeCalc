using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCalc
{
    class ConsoleDriver
    {
        public static void Main()
        {
            bool stop = false;
            MasterDex.InitializePokedex();

            Pokedex dex = new Pokedex();
            Pokemon mon = new Pokemon();
            while (!stop)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case ("get pokemon"):
                        
                        break;
                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }
            }
        }

        public static Pokemon GetPokemon(string key)
        {
            
        }
    }
}

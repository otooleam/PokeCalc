using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCalc
{
    public class Pokedex
    {
        private Dictionary<string, Pokemon> dex { get; }

        public enum Region
        {
            Kanto = 1,
            Johto,
            Hoenn,
            Sinnoh,
            Unova,
            Kalos,
            Alola,
            Galar
        }

        public Pokedex()
        {
            MasterDex.InitializePokedex();
            dex = new Dictionary<string, Pokemon>();
            foreach (Pokemon mon in MasterDex.Pokedex)
            {
                dex.Add(mon.Name, mon);
            }
        }

        public Pokedex(string text)
        {
            foreach (Pokemon mon in MasterDex.Pokedex)
            {
                if (mon.Name.Contains(text))
                    dex.Add(mon.Name, mon);
            }
        }

        public Pokedex(string text, Pokedex prevDex)
        {
            foreach (Pokemon mon in prevDex.dex.Values)
            {
                if (mon.Name.Contains(text))
                    dex.Add(mon.Name, mon);
            }
        }

        public Pokedex(Region gen) //TODO this is gross. Add gen attribute to .json
        {
            switch (gen)
            {
                case Region.Kanto:
                    break;
                case Region.Johto:
                    break;
                case Region.Hoenn:
                    break;
                case Region.Sinnoh:
                    break;
                case Region.Unova:
                    break;
                case Region.Kalos:
                    break;
                case Region.Alola:
                    break;
                case Region.Galar:
                    break;
                default:
                    break;
            }
        }
        public Pokemon GetPokemon(string name)
        {
            if (dex.ContainsKey(name))
                return dex[name];
            return null;
        }

        public Pokemon GetPokemon(short num, string form = "")
        {
            var query =
                (from pokemon in dex.Values
                 where pokemon.Number == num
                 select pokemon).ToList();
            if (query.Count == 1)
                return query[0];
            foreach (Pokemon mon in query)
            {
                if (mon.Name.Contains(form))
                    return mon;
            }
            return null;
        }

        public void PrintDex()
        {
            foreach (Pokemon mon in dex.Values)
                Console.WriteLine(mon.ToString());
        }
        }
    }
}
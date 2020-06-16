﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCalc
{
    public class Pokedex
    {
        private Dictionary<string, Pokemon> dex;

        public Pokedex()
        {
            MasterDex.InitializePokedex();
            dex = new Dictionary<string, Pokemon>();
            foreach (Pokemon mon in MasterDex.Pokedex)
            {
                dex.Add(mon.Name, mon);
            }
        }

        public Pokedex(string text, Pokedex prevDex)//TODO cant see prev dex
        {
            dex = new Dictionary<string, Pokemon>();
            foreach (string mon in prevDex.dex.Keys)
            {
                if (mon.Contains(text))
                    dex.Add(mon, prevDex.dex[mon]);
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

        public Pokemon GetPokemon(string name)
        {
            if (dex.ContainsKey(name))
                return dex[name];
            return null;
        }

        public Pokemon GetPokemon(short num, string form = "default")
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

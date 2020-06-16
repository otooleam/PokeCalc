using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokeCalc
{
    static class MasterDex
    {
        public static List<Pokemon> Pokedex = new List<Pokemon>();

        //Reads Pokedex info from locally stored .json file.
        public static void InitializePokedex()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\amand\\OneDrive\\Documents\\Hobby " +
                "Code\\PokeCalc - Repo\\Data\\.json\\Pokedex.json"))
            {
                string json = r.ReadToEnd();
                List<Pokemon> items = JsonConvert.DeserializeObject<List<Pokemon>>(json);
                Pokedex = items;
            }
        }
    }
}

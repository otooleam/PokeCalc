using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokeCalc;

namespace PokeCalcTest
{
    [TestClass]
    public class PokedexTest
    {
        private Pokemon magsy;
        private Pokedex dex;
        private Pokemon maybeMon;
        private Pokemon alolaMeowth;

        [TestInitialize]
        public void TestInitialize()
        {
            string[] type = { "Fire" };
            magsy = new Pokemon("Arcanine", 59, 207, 227, 166, type);
            //IVs attack:9 defense:14 hp:15

            dex = new Pokedex();
            maybeMon = new Pokemon();

            string[] type1 = { "Dark" };
            alolaMeowth = new Pokemon("Alolan Meowth", 52, 120, 99, 78, type1);
        }

        [TestMethod]
        public void GetByName()
        {
            maybeMon = dex.GetPokemon("Arcanine");

            Assert.AreEqual(magsy, maybeMon);
        }

        [TestMethod]
        public void GetByName_FakeName()
        {
            Pokemon notMagsy = new Pokemon();
            notMagsy = dex.GetPokemon("firepuppy");

            Assert.IsNull(notMagsy);
        }

        [TestMethod]
        public void GetByName_AlolaForm()
        {
            Pokemon maybeMagsy = dex.GetPokemon("Alolan Meowth");
            Assert.AreEqual(alolaMeowth, maybeMagsy);
        }

        [TestMethod]
        public void GetByNumber_SingleForm()
        {
            maybeMon = dex.GetPokemon(59);
            Assert.AreEqual(magsy, maybeMon);
        }

        [TestMethod]
        public void GetByNumber_KantoMeowth()
        {
            string[] type1 = { "Normal" };
            Pokemon kantoMeowth = new Pokemon("Meowth", 52, 120, 92, 78, type1);

            maybeMon = dex.GetPokemon(52);
            Assert.AreEqual(kantoMeowth, maybeMon);
        }

        [TestMethod]
        public void GetByNumber_AlolanMeowth()
        {
            maybeMon = dex.GetPokemon(52, "Alolan");
            Assert.AreEqual(alolaMeowth, maybeMon);
        }


        [TestMethod]
        public void GetByNumber_GalarianMeowth()
        {
            string[] type1 = { "Steel" };
            Pokemon kantoMeowth = new Pokemon("Galarian Meowth", 52, 137, 115, 92, type1);

            maybeMon = dex.GetPokemon(52, "Galarian");
            Assert.AreEqual(kantoMeowth, maybeMon);
        }

        [TestMethod]
        public void GetByNumber_GalarZenModeDarmanitan()
        {
            string[] type1 = { "Fire", "Ice" };
            Pokemon gzmDarm = new Pokemon("Galarian Zen Mode Darmanitan", 555, 233, 323, 123, type1);

            maybeMon = dex.GetPokemon(555, "Galarian Zen Mode");
            Assert.AreEqual(gzmDarm, maybeMon);
        }

        [TestMethod]
        public void GetByNumber_GalarDarmanitan()
        {
            string[] type1 = { "Ice" };
            Pokemon gzmDarm = new Pokemon("Galarian Darmanitan", 555, 233, 263, 114 , type1);

            maybeMon = dex.GetPokemon(555, "Galarian");
            Assert.AreEqual(gzmDarm, maybeMon);
        }
    }
}

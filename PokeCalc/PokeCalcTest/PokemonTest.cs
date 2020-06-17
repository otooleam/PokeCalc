using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokeCalc;

namespace PokeCalcTest
{
    [TestClass]
    public class PokemonTest
    {
        private Pokemon magsy;

        [TestInitialize]
        public void TestInitialize()
        {
            string[] type = { "Fire" };
            magsy = new Pokemon("Arcanine", 59, 207, 227, 166, type);
            //IVs attack:9 defense:14 hp:15
        }

        [TestMethod]
        public void CalculateCP()
        {
            int cp = magsy.CalculateCP(15, 9, 14, 37);
            Assert.AreEqual(2820, cp);
        }

        [TestMethod]
        public void CalculateCP_CalculatedUnderTen()
        {
            Pokemon dummy = new Pokemon("species", 3, 3, 3, 3, null);
            Assert.AreEqual(10, dummy.CalculateCP(0, 0, 0, 1));
        }

        [TestMethod]
        public void CalculateMaxCP_Default()
        {
            Assert.AreEqual(2946, magsy.CalculateMaxCP(15, 9, 14));
        }

        [TestMethod]
        public void CalculateMaxCP_BuddyFalse()
        {
            Assert.AreEqual(2946, magsy.CalculateMaxCP(15, 9, 14, false));
        }

        [TestMethod]
        public void CalculateMaxCP_BuddyTrue()
        {
            Assert.AreEqual(2983, magsy.CalculateMaxCP(15, 9, 14, true));
        }
    }
}

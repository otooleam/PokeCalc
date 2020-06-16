using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCalc
{
    public class Pokemon
    {
        #region attributes
        private Dictionary<double, double> _levelNums = new Dictionary<double, double>()
        {
            { 1, 0.094 },
            { 1.5, 0.1351374318 },
            { 2, 0.16639787 },
            { 2.5, 0.192650919 },
            { 3, 0.21573247 },
            { 3.5, 0.2365726613 },
            { 4, 0.25572005 },
            { 4.5, 0.2735303812 },
            { 5, 0.29024988 },
            { 5.5, 0.3060573775 },
            { 6, 0.3210876 },
            { 6.5, 0.3354450362 },
            { 7, 0.34921268 },
            { 7.5, 0.3624577511 },
            { 8, 0.3752356 },
            { 8.5, 0.387592416 },
            { 9, 0.39956728 },
            { 9.5, 0.4111935514 },
            { 10, 0.4225 },
            { 10.5, 0.4329264091 },
            { 11, 0.44310755 },
            { 11.5, 0.4530599591 },
            { 12, 0.4627984 },
            { 12.5, 0.472336093 },
            { 13, 0.48168495 },
            { 13.5, 0.4908558003 },
            { 14, 0.49985844 },
            { 14.5, 0.508701765 },
            { 15, 0.51739395 },
            { 15.5, 0.5259425113 },
            { 16, 0.5343543 },
            { 16.5, 0.5426357375 },
            { 17, 0.5507927 },
            { 17.5, 0.5588305862 },
            { 18, 0.5667545 },
            { 18.5, 0.5745691333 },
            { 19, 0.5822789 },
            { 19.5, 0.5898879072 },
            { 20, 0.5974 },
            { 20.5, 0.6048236651 },
            { 21, 0.6121573 },
            { 21.5, 0.6194041216 },
            { 22, 0.6265671 },
            { 22.5, 0.6336491432 },
            { 23, 0.64065295 },
            { 23.5, 0.6475809666 },
            { 24, 0.65443563 },
            { 24.5, 0.6612192524 },
            { 25, 0.667934 },
            { 25.5, 0.6745818959 },
            { 26, 0.6811649 },
            { 26.5, 0.6876849038 },
            { 27, 0.69414365 },
            { 27.5, 0.70054287 },
            { 28, 0.7068842 },
            { 28.5, 0.7131691091 },
            { 29, 0.7193991 },
            { 29.5, 0.7255756136 },
            { 30, 0.7317 },
            { 30.5, 0.7347410093 },
            { 31, 0.7377695 },
            { 31.5, 0.7407855938 },
            { 32, 0.74378943 },
            { 32.5, 0.7467812109 },
            { 33, 0.74976104 },
            { 33.5, 0.7527290867 },
            { 34, 0.7556855 },
            { 34.5, 0.7586303683 },
            { 35, 0.76156384 },
            { 35.5, 0.7644860647 },
            { 36, 0.76739717 },
            { 36.5, 0.7702972656 },
            { 37, 0.7731865 },
            { 37.5, 0.7760649616 },
            { 38, 0.77893275 },
            { 38.5, 0.7817900548 },
            { 39, 0.784637 },
            { 39.5, 0.7874736075 },
            { 40, 0.7903 },
            { 41, 0.79530001 },
            { 42, 0.8003 },
            { 43, 0.8053 },
            { 44, 0.81029999 },
            { 45, 0.81529999 }
        };

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private short _number;
        public short Number
        {
            get { return _number; }
            set { _number = value; }
        }

        private short _hp;
        public short Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }

        private short _attack;
        public short Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }

        private short _defense;
        public short Defense
        {
            get { return _defense; }
            set { _defense = value; }
        }

        private string[] _type;
        public string[] Type
        {
            get { return _type; }
            set { _type = value; }
        }
        #endregion

        public Pokemon()
        {
            Name = null;
            Number = 0;
            Attack = 0;
            Defense = 0;
            Hp = 0;
            Type = null;
        }

        public Pokemon(string name, short number, short hp, short attack, short defense, string[] type)
        {
            Number = number;
            Name = name;
            Attack = attack;
            Defense = defense;
            Hp = hp;
            Type = new string[2];
            Type = type;
        }

        public override string ToString()
        {
            string type = Type[0] + (Type.Length == 2 ? "/" + Type[1] : "");
            return $"{Number,-4} {Name,-30} {type,-20}";
        } 

        public override bool Equals(object obj)
        {
            Pokemon mon = (Pokemon)obj;
            return Name == mon.Name && Number == mon.Number;
        }

        public int CalculateCP(short hpIV, short attackIV, short defenseIV, byte level)
        {
            int cp = (int)((Attack + attackIV) * (Math.Sqrt(Defense + defenseIV)) *
                (Math.Sqrt(Hp + hpIV)) * (_levelNums[level] * _levelNums[level])) / 10;
            return (cp >= 10 ? cp : 10);
        }

        public int CalculateMaxCP(short hpIV, short attackIV, short defenseIV, bool buddy = false)
        {
            if (buddy)
                return CalculateCP(hpIV, attackIV, defenseIV, 41);
            return CalculateCP(hpIV, attackIV, defenseIV, 40);
        }


    }
}

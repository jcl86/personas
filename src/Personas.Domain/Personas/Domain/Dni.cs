using System.Linq;

namespace Personas.Domain
{
    public class Dni
    {
        public int Number { get; }

        public Dni(RandomProvider randomProvider)
        {
            foreach (var i in Enumerable.Range(0, 8))
                Number += randomProvider.GetNumber(0, 9) * (int)System.Math.Pow(10, i);
        }

        public override string ToString() => $"{Number}{GetLetra()}";

        private char GetLetra()
        {
            switch (Number % 23)
            {
                case 0: return 'T';
                case 1: return 'R';
                case 2: return 'W';
                case 3: return 'A';
                case 4: return 'G';
                case 5: return 'M';
                case 6: return 'Y';
                case 7: return 'F';
                case 8: return 'P';
                case 9: return 'D';
                case 10: return 'X';
                case 11: return 'B';
                case 12: return 'N';
                case 13: return 'J';
                case 14: return 'Z';
                case 15: return 'S';
                case 16: return 'Q';
                case 17: return 'V';
                case 18: return 'H';
                case 19: return 'L';
                case 20: return 'C';
                case 21: return 'K';
                case 22: return 'E';
                case 23: return 'U';
                default: return '-';
            }
        }
    }
}

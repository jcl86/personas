using System.Linq;

namespace Personas.Domain
{
    public class Dni
    {
        public int Number { get; }

        public Dni(IRandomProvider randomProvider)
        {
            foreach (var i in Enumerable.Range(0, 8))
                Number += randomProvider.GetNumber(0, 9) * (int)System.Math.Pow(10, i);
        }

        public override string ToString() => $"{Number}{GetLetra()}";

        private char GetLetra()
        {
            return (Number % 23) switch
            {
                0 => 'T',
                1 => 'R',
                2 => 'W',
                3 => 'A',
                4 => 'G',
                5 => 'M',
                6 => 'Y',
                7 => 'F',
                8 => 'P',
                9 => 'D',
                10 => 'X',
                11 => 'B',
                12 => 'N',
                13 => 'J',
                14 => 'Z',
                15 => 'S',
                16 => 'Q',
                17 => 'V',
                18 => 'H',
                19 => 'L',
                20 => 'C',
                21 => 'K',
                22 => 'E',
                23 => 'U',
                _ => '-',
            };
        }
    }
}

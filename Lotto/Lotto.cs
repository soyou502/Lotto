using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Lotto
    {
        private int number;
        private int firnum;
        private int secnum;
        private int thirnum;
        private int fournum;
        private int fifnum;
        private int sixnum;
        private int bonusnum;


        public Lotto(int number, int firnum, int secnum, int thirnum, int fournum, int fifnum, int sixnum, int bonusnum)
        {
            this.Number = number;
            this.Firnum = firnum;
            this.Secnum = secnum;
            this.Thirnum = thirnum;
            this.Fournum = fournum;
            this.Fifnum = fifnum;
            this.Sixnum = sixnum;
            this.Bonusnum = bonusnum;
        }
        
        public int Number { get => number; set => number = value; }
        public int Firnum { get => firnum; set => firnum = value; }
        public int Secnum { get => secnum; set => secnum = value; }
        public int Thirnum { get => thirnum; set => thirnum = value; }
        public int Fournum { get => fournum; set => fournum = value; }
        public int Fifnum { get => fifnum; set => fifnum = value; }
        public int Sixnum { get => sixnum; set => sixnum = value; }
        public int Bonusnum { get => bonusnum; set => bonusnum = value; }

    }
}

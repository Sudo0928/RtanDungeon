using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle.Stat
{
    public class ExtraStat
    {
        public ExtraStat(uint hp, uint attackPower, uint defensePower)
        {
            Hp = hp;
            AttackPower = attackPower;
            DefensePower = defensePower;
        }

        public uint Hp { get; }
        public uint AttackPower { get; }
        public uint DefensePower { get; }
    }
}

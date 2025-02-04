using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle.Stat
{
    public class EntityStat
    {
        public EntityStat(uint hp, uint attackPower, uint defensePower)
        {
            MaxHp = hp;
            CurrentHp = hp;
            AttackPower = attackPower;
            DefensePower = defensePower;
        }

        public uint MaxHp { get; internal set; }
        public uint CurrentHp { get; internal set; }
        public uint AttackPower { get; internal set; }
        public uint DefensePower { get; internal set; }

        internal void AddHp(uint hp)
        {
            if (MaxHp > CurrentHp + hp) CurrentHp += hp;
            else CurrentHp = MaxHp;
        }
    }
}

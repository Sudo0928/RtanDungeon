using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle.Character
{
    internal abstract class Character
    {
        public Character(string name)
        {
            Name = name;

            State = new Stats();
            SetStats(1, 10, 5, 100);

            Inventory = new Inventory();
        }

        public Character(string name, Stats stats)
        {
            Name = name;
            State = stats;
            Inventory = new Inventory();
        }

        public string Name { get; protected set; }
        public Stats State { get; protected set; }
        public uint CurrentGold { get; protected set; } = 1500;
        public Inventory Inventory { get; protected set; }

        private void SetStats(uint level, uint attackPower, uint DefensePower, uint Hp)
        {
            State.Level = level;
            State.AttackPower = attackPower;
            State.DefensePower = DefensePower;
            State.Hp = Hp;
        }

        public void AddGold(uint gold)
        {
            CurrentGold += gold;
        }

        public void SubGold(uint gold)
        {
            if(CurrentGold > gold) CurrentGold -= gold;
            else CurrentGold = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RtanDungeon.Modle.Stat;

namespace RtanDungeon.Modle.Character.Enemy
{
    internal class Enemy : Entity
    {
        public Enemy(string name) : base(name)
        {
        }

        public Enemy(string name, EntityStat stats) : base(name, stats)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle.Character.Enemy
{
    internal class Enemy : Character
    {
        public Enemy(string name) : base(name)
        {
        }

        public Enemy(string name, Stats stats) : base(name, stats)
        {
        }
    }
}

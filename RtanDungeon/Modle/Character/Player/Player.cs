using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RtanDungeon.Utility;

namespace RtanDungeon.Modle.Character.Player
{
    internal class Player : Character
    {
        public Player(string name) : base(name)
        {
            Job = Job.WARRIOR;
        }

        public Player(string name, Job job) : base(name)
        {
            Job = job;
        }

        public Player(string name, Stats stats, Job job) : base(name, stats)
        {
            Job = job;
        }

        public Job Job { get; private set; }
    }
}

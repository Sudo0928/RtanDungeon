using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RtanDungeon.Modle.Stat;
using RtanDungeon.Utility;

namespace RtanDungeon.Modle.Character.Player
{
    public class Player : Entity
    {
        public Player(string name) : base(name)
        {
            Job = Job.WARRIOR;
        }

        public Player(string name, Job job) : base(name)
        {
            Job = job;
        }

        public Player(string name, EntityStat stats, Job job) : base(name, stats)
        {
            Job = job;
        }

        public Job Job { get; private set; }
    }
}

using RtanDungeon.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle.Items
{
    internal class EquipItem : Item
    {
        public Stats Stats { get; protected set; }
        public EquipSlot Slot { get; protected set; }

        public EquipItem(string name, Stats stats, EquipSlot slot) : base(name)
        {
            Stats = stats;
            Slot = slot;
        }

        public EquipItem(string name, Stats stats, EquipSlot slot, string description) : base(name, description)
        {
            Stats = stats;
            Slot = slot;
        }
    }
}

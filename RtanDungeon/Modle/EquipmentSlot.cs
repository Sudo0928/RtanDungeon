using RtanDungeon.Modle.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle
{
    internal class EquipmentSlot
    {
        public EquipItem Helmat { get; private set; }
        public EquipItem Chestplates { get; private set; }
        public EquipItem Leggings { get; private set; }
        public EquipItem Boots { get; private set; }
        public EquipItem Weapon { get; private set; }
        public EquipItem Accessory { get; private set; }

        public void EquipItem(EquipItem item)
        {
            switch (item.Slot)
            {
                case Utility.EquipSlot.HELMET:
                    Helmat = item;
                    break;
                case Utility.EquipSlot.CHESTPLATE:
                    Chestplates = item;
                    break;
                case Utility.EquipSlot.LEGGINGS:
                    Leggings = item;
                    break;
                case Utility.EquipSlot.BOOTS:
                    Boots = item;
                    break;
                case Utility.EquipSlot.WEAPON:
                    Weapon = item;
                    break;
                case Utility.EquipSlot.ACCESSORY:
                    Accessory = item;
                    break;
            }
        }
    }
}

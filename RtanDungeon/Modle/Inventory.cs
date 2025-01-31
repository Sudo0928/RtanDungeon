using RtanDungeon.Modle.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle
{
    internal class Inventory
    {
        public EquipmentSlot EquipmentSlot { get; private set; }

        public List<Item> items { get; private set; }

        public Inventory()
        {
            EquipmentSlot = new EquipmentSlot();
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }
    }
}

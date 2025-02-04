using RtanDungeon.Modle.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle
{
    public class Inventory
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

        public string GetEquipItemListToString()
        {
            string s = "";

            for(int i = 0; i < items.Count; i++)
            {
                if (items[i].GetType() != typeof(EquipItem)) continue;
                s += $"- {i + 1} {items[i].GetItemInformation()} \n";
            }

            return s;
        }

        public string GetItemListToString()
        {
            string s = "";

            for (int i = 0; i < items.Count; i++)
            {
                s += $"- {i + 1} {items[i].GetItemInformation()} \n";
            }

            return s;
        }
    }
}

using RtanDungeon.Modle.Character.Player;
using RtanDungeon.Modle.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle
{
    public class Shop
    {
        public Shop() { }

        public Shop(List<(Item, uint)> items)
        {
            this.items = items;
        }

        private List<(Item, uint)> items = new List<(Item, uint)>();
        public int Count => items.Count;

        public void AddItem(Item item, uint price)
        {
            items.Add((item, price));
        }

        public void RemoveItem(int index)
        {
            items.RemoveAt(index);
        }

        public void BuyItem(Player player, int index)
        {
            if (items[index].Item2 == 0)
            {
                Message("이미 구매한 아이템입니다.");
            }
            else if(player.CurrentGold >= items[index].Item2)
            {
                player.SubGold(items[index].Item2);
                Item item = items[index].Item1.Clone();
                player.Inventory.AddItem(item);
                items[index] = (items[index].Item1, 0);
            }
            else
            {
                Message("Gold가 부족합니다.");
            }
        }

        private void Message(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(700);
        }

        public string GetShopItemsToString()
        {
            string s = "";

            for (int i = 0; i < items.Count; i++)
            {
                s += $"- {i + 1} {items[i].Item1.GetItemInformation()}| {GetPriceToString(i)} \n";
            }

            return s;
        }

        private string GetPriceToString(int index)
        {
            if (items[index].Item2 == 0) return "판매완료";
            else return items[index].Item2 + " G";
        }
    }
}

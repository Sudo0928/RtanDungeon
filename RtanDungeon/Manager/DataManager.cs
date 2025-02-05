using RtanDungeon.Interface;
using RtanDungeon.Manager.Data;
using RtanDungeon.Modle;
using RtanDungeon.Modle.Items;
using RtanDungeon.Modle.Items.ActiveEffect;
using RtanDungeon.Modle.Stat;
using RtanDungeon.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Manager
{
    public class DataManager
    {
        private ItemDB ItemDB = new ItemDB();
        public ViewDB ViewDB = new ViewDB();

        public Item GetItem(uint index)
        {
            if(ItemDB.Items.TryGetValue(index, out var item))
            {
                return item;
            }
            else new Exception("This item code is not exsist");

            return null;
        }
    }
}

using RtanDungeon.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle.Items
{
    public abstract class Item
    {
        protected string name;
        protected string description;

        public Item(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public virtual string GetDescription()
        {
            return description;
        }

        public virtual string GetItemName()
        {
            return name;
        }

        public virtual string GetItemInformation()
        {
            return $"{GetItemName()} | {description}";
        }

        public abstract Item Clone();
    }
}

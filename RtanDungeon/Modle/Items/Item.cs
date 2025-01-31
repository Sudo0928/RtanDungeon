using RtanDungeon.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle.Items
{
    internal class Item
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        public Item(string name)
        {
            Name = name;
            Description = "null";
        }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual string GetDescription()
        {
            return Description;
        }
    }
}

using RtanDungeon.Modle.Stat;
using RtanDungeon.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle.Items
{
    public class EquipItem : Item
    {
        public ExtraStat Stat { get; protected set; }
        public EquipSlot Slot { get; protected set; }
        public bool IsEquipped { get; protected set; }

        public EquipItem(string name, string description, EquipSlot slot, ExtraStat stat) : base(name, description)
        {
            Stat = stat;
            Slot = slot;
            IsEquipped = false;
        }

        public void SetEquipped(bool value)
        {
            IsEquipped = value;
        }

        public void ToggleEquipped()
        {
            IsEquipped = !IsEquipped;
        }

        public override string GetItemName()
        {
            string s = name;
            if (IsEquipped) s = "[E]" + s;
            return s;
        }

        public string GetItemStatInformation()
        {
            string s = "";
            if(Stat.Hp > 0) s += $"| 체력 +{Stat.Hp.ToString()} ";
            if(Stat.AttackPower > 0) s += $"| 공격력 +{Stat.AttackPower.ToString()} ";
            if(Stat.DefensePower > 0) s += $"| 방어력 +{Stat.DefensePower.ToString()} ";
            return s;
        }

        public override string GetItemInformation()
        {
            string s = $"{GetItemName()} | {description} {GetItemStatInformation()}";
            return s;
        }

        public override Item Clone()
        {
            return new EquipItem(name, description, Slot, Stat);
        }
    }
}

﻿using RtanDungeon.Modle.Items;
using RtanDungeon.Modle.Stat;
using RtanDungeon.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle
{
    public class EquipmentSlot
    {
        private EquipItem[] equipItems = new EquipItem[Enum.GetValues(typeof(EquipSlot)).Length];

        public event Action<int>? OnChangeHp;

        public void ItemEquip(EquipItem item)
        {
            if (item == null) return;

            int index = (int)item.Slot;
            int changeHp = 0;

            if (equipItems[index] != null)
            {
                equipItems[index].SetEquipped(false);
                changeHp -= (int)equipItems[index].Stat.Hp;
            }

            if (equipItems[index] == item)
            {
                equipItems[index].SetEquipped(false);
                equipItems[index] = null;
            }
            else
            {
                equipItems[index] = item;
                equipItems[index].SetEquipped(true);
                changeHp += (int)equipItems[index].Stat.Hp;
            }

            if(changeHp != 0) OnChangeHp?.Invoke(changeHp);
        }

        public uint GetTotalHpStat()
        {
            uint hp = 0;

            foreach (var item in equipItems)
            {
                if (item == null) continue;
                hp += item.Stat.Hp;
            }

            return hp;
        }

        public string GetTotalHpStatToString()
        {
            uint totalHp = GetTotalHpStat();

            return GetStatToString(totalHp);
        }

        public uint GetTotalDamageStat()
        {
            uint damage = 0;

            foreach (var item in equipItems)
            {
                if (item == null) continue;
                damage += item.Stat.AttackPower;
            }

            return damage;
        }

        public string GetTotalDamageStatToString()
        {
            uint totalDamage = GetTotalDamageStat();

            return GetStatToString(totalDamage);
        }

        public uint GetTotalDefenseStat()
        {
            uint defense = 0;

            foreach (var item in equipItems)
            {
                if (item == null) continue;
                defense += item.Stat.DefensePower;
            }

            return defense;
        }

        public string GetTotalDefenseStatToString()
        {
            uint totalDefense = GetTotalDefenseStat();

            return GetStatToString(totalDefense);
        }

        private string GetStatToString(uint stat)
        {
            if (stat > 0) return $"(+{stat})";
            else return "";
        }

        public ExtraStat GetTotalEquipItemStat()
        {
            uint hp = GetTotalHpStat();
            uint damage = GetTotalDamageStat();
            uint defense = GetTotalDefenseStat();

            return new ExtraStat(hp, damage, defense);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RtanDungeon.Modle.Stat;

namespace RtanDungeon.Modle.Character
{
    public abstract class Entity
    {
        public Entity(string name)
        {
            Name = name;
            Level = 1;
            Stat = new EntityStat(10, 5, 100);
            Inventory = new Inventory();
            Inventory.EquipmentSlot.OnChangeHp += OnChangeHp;
        }

        public Entity(string name, EntityStat stats)
        {
            Name = name;
            Level = 1;
            Stat = stats;
            Inventory = new Inventory();
            Inventory.EquipmentSlot.OnChangeHp += OnChangeHp;
        }

        public string Name { get; protected set; }
        public uint Level { get; internal set; }
        public EntityStat Stat { get; protected set; }
        public uint CurrentGold { get; protected set; } = 1500;
        public Inventory Inventory { get; protected set; }

        public void AddGold(uint gold)
        {
            CurrentGold += gold;
        }

        public void SubGold(uint gold)
        {
            if(CurrentGold > gold) CurrentGold -= gold;
            else CurrentGold = 0;
        }

        public uint GetTotalHp()
        {
            return Inventory.EquipmentSlot.GetTotalHpStat() + Stat.CurrentHp;
        }

        public uint GetTotalAttackPower()
        {
            return Inventory.EquipmentSlot.GetTotalDamageStat() + Stat.AttackPower;
        }

        public uint GetTotalDefensePower()
        {
            return Inventory.EquipmentSlot.GetTotalDefenseStat() + Stat.DefensePower;
        }

        private void OnChangeHp(int changeHp)
        {
            Stat.MaxHp += (uint)changeHp;
            Stat.CheckHp();
        }
    }
}

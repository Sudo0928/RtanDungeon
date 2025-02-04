using RtanDungeon.Interface;
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
        private Dictionary<uint, Item> ItemDB = new Dictionary<uint, Item>()
        {
            { 1000, new ActiveItem("체력 물약", "사용시 체력을 10 회복한다.", new List<IActiveEffect>(){ new HpRecovery(10) } ) },
            { 1001, new ActiveItem("체력 물약", "사용시 체력을 50 회복한다.", new List<IActiveEffect>(){ new HpRecovery(50) }) },
            { 1002, new ActiveItem("체력 물약", "사용시 체력을 100 회복한다.", new List<IActiveEffect>(){ new HpRecovery(100) }) },
            { 1003, new ActiveItem("체력 물약", "사용시 체력을 200 회복한다.", new List<IActiveEffect>(){ new HpRecovery(200) }) },
            { 1004, new ActiveItem("체력 물약", "사용시 체력을 전부 회복한다.", new List<IActiveEffect>(){ new HpRecovery(999999) }) },
            { 2000, new EquipItem("낡은 나무 검", "사용감이 많아 얼마 못 쓸거 같다.", EquipSlot.WEAPON, new ExtraStat(0, 1, 0)) },
            { 2001, new EquipItem("나무 검", "가장 기본적인 연습용 검", EquipSlot.WEAPON, new ExtraStat(0, 2, 0)) },
            { 2002, new EquipItem("낡은 녹슨 철제 검", "낡고 관리가 안 되어있어 상태가 안 좋다.", EquipSlot.WEAPON, new ExtraStat(0, 3, 0)) },
            { 2003, new EquipItem("녹슨 첼제 검", "관리가 안 되어있어 상태가 안 좋다.", EquipSlot.WEAPON, new ExtraStat(0, 5, 0)) },
            { 2004, new EquipItem("낡은 철제 검", "낡지만 관리가 잘 되어 있어 그럭저럭 쓸만하다.", EquipSlot.WEAPON, new ExtraStat(0, 7, 0)) },
            { 2005, new EquipItem("철제 검", "철로 만들어진 검", EquipSlot.WEAPON, new ExtraStat(0, 10, 0)) },
            { 3000, new EquipItem("낡은 가죽 투구", "사용감이 많아 너덜너덜하다.", EquipSlot.HELMET, new ExtraStat(0, 0, 1)) },
            { 4000, new EquipItem("낡은 가죽 갑옷", "사용감이 많아 너덜너덜하다.", EquipSlot.CHESTPLATE, new ExtraStat(0, 0, 2)) },
            { 5000, new EquipItem("낡은 가죽 바지", "사용감이 많아 너덜너덜하다.", EquipSlot.LEGGINGS, new ExtraStat(0, 0, 2)) },
            { 6000, new EquipItem("낡은 가죽 신발", "사용감이 많아 너덜너덜하다.", EquipSlot.BOOTS, new ExtraStat(0, 0, 1)) },
            { 7000, new EquipItem("낡은 나무 팔찌", "사용감이 많아 너덜너덜하다.", EquipSlot.ACCESSORY, new ExtraStat(2, 0, 0)) },
            { 9000, new EquipItem("개발자의 목걸이", "Error", EquipSlot.ACCESSORY, new ExtraStat(999, 999, 999)) },
        };

        public Item GetItem(uint index)
        {
            if(ItemDB.TryGetValue(index, out var item))
            {
                return item;
            }
            else new Exception("This item code is not exsist");

            return null;
        }
    }
}

using RtanDungeon.Modle;
using RtanDungeon.Modle.Character.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Manager.Data
{
    public class ViewDB
    {
        public void SendMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("\n계속 하려면 아무키나 누르세요.");
            Console.ReadKey();
            Console.Clear();
        }

        public string InputField()
        {
            return "원하시는 행동을 입력해주세요. \n" +
                ">> ";
        }

        public string Village()
        {
            return "스파르타 마을에 오신 여러분 환영합니다. \n" +
                "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다. \n" +
                "\n" +
                "1. 상태 보기 \n" +
                "2. 인벤토리 \n" +
                "3. 상점 \n" +
                "4. 던전입장 \n" +
                "5. 휴식하기 \n" +
                "0. 게임 종료 \n";
        }

        public string Dungeon()
        {
            return "스파르타 던전. \n" +
                "이곳에서 던전에서의 활동을 결정할 수 있습니다. \n" +
                "\n" +
                "1. 상태 보기 \n" +
                "2. 인벤토리 \n" +
                "0. 돌아가기 \n";
        }

        public string PlayerStat(Player player)
        {
            return $"상태보기 \n" +
                $"캐릭터의 정보가 표시됩니다. \n" +
                $"\n" +
                $"{player.Name} ( {player.Job} ) \n" +
                $"Lv. \t: {player.Level} \n" +
                $"체 력 \t: {player.Stat.CurrentHp} / {player.Stat.MaxHp} {player.Inventory.EquipmentSlot.GetTotalHpStatToString()} \n" +
                $"공격력 \t: {player.Stat.AttackPower} {player.Inventory.EquipmentSlot.GetTotalDefenseStatToString()} \n" +
                $"방어력 \t: {player.Stat.DefensePower} {player.Inventory.EquipmentSlot.GetTotalDamageStatToString()} \n" +
                $"Gold \t: {player.CurrentGold} G \n" +
                $"\n" +
                $"0. 나가기 \n";
        }

        public string PlayerInventory(Player player)
        {
            return $"인벤토리 \n" +
                $"보유 중인 아이템을 관리할 수 있습니다. \n" +
                $"\n" +
                $"[아이템 목록] \n" +
                $"{player.Inventory.GetItemListToString()}" +
                $"\n" +
                $"1. 장착 관리 \n" +
                $"2. 아이템 사용 \n" +
                $"0. 나가기 \n";
        }

        public string ActiveItemManagement(Player player)
        {
            return $"인벤토리 - 아이템 사용 \n" +
                $"보유 중인 아이템을 사용할 수 있습니다. \n" +
                $"\n" +
            $"[아이템 목록] \n" +
                $"{player.Inventory.GetActiveItemListToString()}" +
                $"\n" +
                $"0. 나가기 \n";
        }

        public string EquipManagement(Player player)
        {
            return $"인벤토리 - 장착 관리 \n" +
                $"보유 중인 아이템을 관리할 수 있습니다. \n" +
                $"\n" +
                $"[아이템 목록] \n" +
                $"{player.Inventory.GetEquipItemListToString()}" +
                $"\n" +
                $"0. 나가기 \n";
        }

        public string Shop(Player player, Shop shop)
        {
            return $"상점 \n" +
                $"필요한 아이템을 얻을 수 있는 상점입니다.\n" +
                $"\n" +
                $"[보유 골드] \n" +
                $"{player.CurrentGold} G \n" +
                $"\n" +
            $"[아이템 목록] \n" +
                $"{shop.GetShopItemsToString()}" +
                $"\n" +
                $"0. 나가기 \n";
        }

        public string Rest(Player player)
        {
            return $"휴식하기 \n" +
                $"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {player.CurrentGold} G)\n" +
                $"\n" +
                $"1. 휴식하기 \n" +
                $"0. 나가기 \n";
        }
    }
}

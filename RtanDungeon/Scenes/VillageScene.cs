using RtanDungeon.Interface;
using RtanDungeon.Manager;
using RtanDungeon.Modle;
using RtanDungeon.Modle.Character.Player;
using RtanDungeon.Modle.Items;
using RtanDungeon.Modle.Items.ActiveEffect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Scenes
{
    internal class VillageScene : IScene
    {
        private Player player;
        private DataManager dataManager;
        private Shop shop = new Shop();

        private delegate void View();
        private View currentView;

        public string GetTitleName()
        {
            return "Village";
        }

        public void Start()
        {
            player = GameManager.Instance.Player;
            dataManager = GameManager.Instance.DataManager;

            shop.AddItem(dataManager.GetItem(1000), 50);
            shop.AddItem(dataManager.GetItem(9000), 50);

            currentView = new View(Village);
        }

        public void Update()
        {
            Console.Clear();
            currentView();
        }

        public void Village()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다. \n" +
                "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다. \n" +
                "\n" +
                "1. 상태 보기 \n" +
                "2. 인벤토리 \n" +
                "3. 상점 \n" +
                "\n" +
                "원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string num = Console.ReadLine();

            switch (num)
            {
                case "1":
                    currentView = new View(ViewStat);
                    break;
                case "2":
                    currentView = new View(ViewInventory);
                    break;
                case "3":
                    currentView = new View(ViewShop);
                    break;
                default:
                    ViewError();
                    break;
            }
        }

        public void ViewError()
        {
            Console.Clear();
            Console.WriteLine("잘못된 입력 입니다.");
            Thread.Sleep(500);
            Console.Clear();
        }
        public void ViewStat()
        {
            Console.WriteLine($"상태보기 \n" +
                $"캐릭터의 정보가 표시됩니다. \n" +
                $"\n" +
                $"{player.Name} ( {player.Job} ) \n" +
                $"Lv. \t: {player.Level} \n" +
                $"체 력 \t: {player.Stat.CurrentHp} / {player.Stat.MaxHp} {player.Inventory.EquipmentSlot.GetTotalHpStatToString()} \n" +
                $"공격력 \t: {player.Stat.AttackPower} {player.Inventory.EquipmentSlot.GetTotalDefenseStatToString()} \n" +
                $"방어력 \t: {player.Stat.DefensePower} {player.Inventory.EquipmentSlot.GetTotalDamageStatToString()} \n" +
                $"Gold \t: {player.CurrentGold} G \n" +
                $"\n" +
                $"0. 나가기 \n" +
                $"\n" +
                $"원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string num = Console.ReadLine();

            switch (num)
            {
                case "0":
                    currentView = new View(Village);
                    break;
                default:
                    ViewError();
                    break;
            }
        }

        public void ViewInventory()
        {
            Console.WriteLine($"인벤토리 \n" +
                $"보유 중인 아이템을 관리할 수 있습니다. \n" +
                $"\n" +
                $"[아이템 목록] \n" +
                $"{player.Inventory.GetItemListToString()}" +
                $"\n" +
                $"1. 장착 관리 \n" +
                $"0. 나가기 \n" +
                $"\n" +
                $"원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string num = Console.ReadLine();

            switch (num)
            {
                case "0":
                    currentView = new View(Village);
                    break;
                case "1":
                    currentView = new View(ViewEquipManagement);
                    break;
                default:
                    ViewError();
                    break;
            }
        }

        public void ViewEquipManagement()
        {
            Console.WriteLine($"인벤토리 - 장착 관리 \n" +
                $"보유 중인 아이템을 관리할 수 있습니다. \n" +
                $"\n" +
                $"[아이템 목록] \n" +
                $"{player.Inventory.GetEquipItemListToString()}" +
                $"\n" +
                $"0. 나가기 \n" +
                $"\n" +
                $"원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine();

            if(Int32.TryParse(input, out var num))
            {
                if(num == 0) currentView = new View(ViewInventory);

                if (0 < num && num <= player.Inventory.items.Count)
                {
                    Inventory inventory = player.Inventory;
                    EquipItem item = inventory.items[num - 1] as EquipItem;
                    inventory.EquipmentSlot.ItemEquip(item);
                }
            }
            else ViewError();
        }

        public void ViewShop()
        {
            

            Console.WriteLine($"상점 \n" +
                $"필요한 아이템을 얻을 수 있는 상점입니다.\n" +
                $"\n" +
                $"[보유 골드] \n" +
                $"{player.CurrentGold} G \n" +
                $"\n" +
                $"[아이템 목록] \n" +
                $"{shop.GetShopItemsToString()}" +
                $"\n" +
                $"0. 나가기 \n" +
                $"\n" +
                $"원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine();

            if (Int32.TryParse(input, out var num))
            {
                if (num == 0) currentView = new View(ViewInventory);

                if (0 < num && num <= shop.Count)
                {
                    shop.BuyItem(player, num - 1);
                }
            }
            else ViewError();
        }
    }
}

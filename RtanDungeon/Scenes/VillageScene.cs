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

            Init();

            currentView = new View(Village);
        }

        public void Update()
        {
            Console.Clear();
            currentView();
        }

        public void Init()
        {
            shop.AddItem(dataManager.GetItem(1000), 50);
            shop.AddItem(dataManager.GetItem(1001), 250);
            shop.AddItem(dataManager.GetItem(1002), 500);
            shop.AddItem(dataManager.GetItem(1003), 1000);
            shop.AddItem(dataManager.GetItem(1004), 100000);
            shop.AddItem(dataManager.GetItem(2000), 10);
            shop.AddItem(dataManager.GetItem(2001), 20);
            shop.AddItem(dataManager.GetItem(2002), 30);
            shop.AddItem(dataManager.GetItem(2003), 50);
            shop.AddItem(dataManager.GetItem(2004), 100);
            shop.AddItem(dataManager.GetItem(2005), 200);
            shop.AddItem(dataManager.GetItem(3000), 50);
            shop.AddItem(dataManager.GetItem(4000), 100);
            shop.AddItem(dataManager.GetItem(5000), 100);
            shop.AddItem(dataManager.GetItem(6000), 50);
            shop.AddItem(dataManager.GetItem(7000), 100);
            shop.AddItem(dataManager.GetItem(9000), 99999999);
        }

        public void Village()
        {
            Console.WriteLine(dataManager.ViewDB.Village());
            Console.Write(dataManager.ViewDB.InputField());
            string input = Console.ReadLine();

            if (Int32.TryParse(input, out var num))
            {
                switch (num)
                {
                    case 0:
                        SceneManager.QuitGame();
                        break;
                    case 1:
                        currentView = new View(Stat);
                        break;
                    case 2:
                        currentView = new View(Inventory);
                        break;
                    case 3:
                        currentView = new View(Shop);
                        break;
                    case 5:
                        currentView = new View(Rest);
                        break;
                    default:
                        dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
                        break;
                }
            }
            else dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
        }

        public void Stat()
        {
            Console.WriteLine(dataManager.ViewDB.PlayerStat(player));
            Console.Write(dataManager.ViewDB.InputField());
            string input = Console.ReadLine();

            if (Int32.TryParse(input, out var num))
            {
                switch (num)
                {
                    case 0:
                        currentView = new View(Village);
                        break;
                    default:
                        dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
                        break;
                }
            }
            else dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
        }

        public void Inventory()
        {
            Console.WriteLine(dataManager.ViewDB.PlayerInventory(player));
            Console.Write(dataManager.ViewDB.InputField());
            string input = Console.ReadLine();

            if(Int32.TryParse(input, out var num))
            {
                switch (num)
                {
                    case 0:
                        currentView = new View(Village);
                        break;
                    case 1:
                        currentView = new View(EquipManagement);
                        break;
                    case 2:
                        currentView = new View(ActiveItemManagement);
                        break;
                    default:
                        dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
                        break;
                }
            }
            else dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
        }

        public void ActiveItemManagement()
        {
            Console.WriteLine(dataManager.ViewDB.ActiveItemManagement(player));
            Console.Write(dataManager.ViewDB.InputField());
            string input = Console.ReadLine();

            if (Int32.TryParse(input, out var num))
            {
                if (num == 0) currentView = new View(Inventory);

                if (0 < num && num <= player.Inventory.items.Count)
                {
                    Inventory inventory = player.Inventory;
                    ActiveItem item = inventory.items[num - 1] as ActiveItem;
                    if(item != null)
                    {
                        item.UseItem(player);
                        inventory.RemoveItem(num - 1);
                    }
                    else dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
                }
            }
            else dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
        }

        public void EquipManagement()
        {
            Console.WriteLine(dataManager.ViewDB.EquipManagement(player));
            Console.Write(dataManager.ViewDB.InputField());
            string input = Console.ReadLine();

            if(Int32.TryParse(input, out var num))
            {
                if(num == 0) currentView = new View(Inventory);

                if (0 < num && num <= player.Inventory.items.Count)
                {
                    Inventory inventory = player.Inventory;
                    EquipItem item = inventory.items[num - 1] as EquipItem;
                    if(item != null)
                    {
                        inventory.EquipmentSlot.ItemEquip(item);
                    }
                    else dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
                }
            }
            else dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
        }

        public void Shop()
        {
            Console.WriteLine(dataManager.ViewDB.Shop(player, shop));
            Console.Write(dataManager.ViewDB.InputField());
            string input = Console.ReadLine();

            if (Int32.TryParse(input, out var num))
            {
                if (num == 0) currentView = new View(Village);

                if (0 < num && num <= shop.Count)
                {
                    shop.BuyItem(player, num - 1);
                }
            }
            else dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
        }

        public void Rest()
        {
            Console.WriteLine(dataManager.ViewDB.Rest(player));
            Console.Write(dataManager.ViewDB.InputField());

            string input = Console.ReadLine();

            if (Int32.TryParse(input, out var num))
            {
                switch (num)
                {
                    case 0:
                        currentView = new View(Village);
                        break;
                    case 1:
                        if(player.Stat.CurrentHp == player.Stat.MaxHp) dataManager.ViewDB.SendMessage($"현재 최대 체력 입니다.");
                        else if(player.CurrentGold >= 500)
                        {
                            uint temp = player.Stat.CurrentHp;
                            player.Stat.AddHp(100);
                            player.SubGold(500);
                            dataManager.ViewDB.SendMessage($"체 력 : {temp} -> {player.Stat.CurrentHp}");
                        }
                        else dataManager.ViewDB.SendMessage($"골드가 부족합니다.");
                        break;
                }
            }
            else dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
        }
    }
}

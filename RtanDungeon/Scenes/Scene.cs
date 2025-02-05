using RtanDungeon.Manager;
using RtanDungeon.Modle;
using RtanDungeon.Modle.Character.Player;
using RtanDungeon.Modle.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Scenes
{
    public abstract class Scene
    {
        protected Player? player;
        protected DataManager? dataManager;

        protected delegate void View();
        protected View? currentView;
        protected View? preView;

        public virtual void Start()
        {
            player = GameManager.Instance.Player;
            dataManager = GameManager.Instance.DataManager;
        }
        public abstract void Update();
        public abstract string GetTitleName();

        public void Stat()
        {
            Console.WriteLine(dataManager.ViewDB.PlayerStat(player));
            Console.Write(dataManager.ViewDB.InputField());
            string input = Console.ReadLine();

            if (int.TryParse(input, out var num))
            {
                switch (num)
                {
                    case 0:
                        currentView = new View(preView);
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

            if (int.TryParse(input, out var num))
            {
                switch (num)
                {
                    case 0:
                        if (preView != null)
                        {
                            currentView = new View(preView);
                        }
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

            if (int.TryParse(input, out var num))
            {
                if (num == 0) currentView = new View(Inventory);

                if (0 < num && num <= player.Inventory.items.Count)
                {
                    Inventory inventory = player.Inventory;
                    ActiveItem item = inventory.items[num - 1] as ActiveItem;
                    if (item != null)
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

            if (int.TryParse(input, out var num))
            {
                if (num == 0) currentView = new View(Inventory);

                if (0 < num && num <= player.Inventory.items.Count)
                {
                    Inventory inventory = player.Inventory;
                    EquipItem item = inventory.items[num - 1] as EquipItem;
                    if (item != null)
                    {
                        inventory.EquipmentSlot.ItemEquip(item);
                    }
                    else dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
                }
            }
            else dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
        }
    }
}

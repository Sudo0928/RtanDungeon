using RtanDungeon.Manager;
using RtanDungeon.Modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Scenes
{
    internal class DungeonScene : Scene
    {
        public override string GetTitleName()
        {
            return "Dungeon";
        }

        public override void Start()
        {
            base.Start();

            currentView = new View(Dungeon);
        }

        public override void Update()
        {
            Console.Clear();
            currentView?.Invoke();
        }

        public void Dungeon()
        {
            Console.WriteLine(dataManager.ViewDB.Dungeon());
            Console.Write(dataManager.ViewDB.InputField());
            string input = Console.ReadLine();

            if (Int32.TryParse(input, out var num))
            {
                switch (num)
                {
                    case 0:
                        SceneManager.LoadScene("VillageScene");
                        break;
                    case 1:
                        currentView = new View(Stat);
                        break;
                    case 2:
                        currentView = new View(Inventory);
                        break;
                    default:
                        dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
                        break;
                }

                preView = new View(Dungeon);
            }
            else dataManager.ViewDB.SendMessage("잘못된 입력 입니다.");
        }
    }
}

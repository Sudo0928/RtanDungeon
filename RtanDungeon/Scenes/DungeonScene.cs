using RtanDungeon.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Scenes
{
    internal class DungeonScene : IScene
    {
        public string GetTitleName()
        {
            return "Dungeon";
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            Console.WriteLine("Dungeon");
        }
    }
}

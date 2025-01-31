using RtanDungeon.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Scenes
{
    internal class MainScene : IScene
    {
        public void Main(string[] args)
        {
            Console.WriteLine("test");

            string command = Console.ReadLine();
            if (command == "exit") SceneManager.LoadScene("DungeonScene");
        }
    }
}

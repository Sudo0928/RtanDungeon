using RtanDungeon.Interface;
using RtanDungeon.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Scenes
{
    internal class MainScene : IScene
    {
        public string GetTitleName()
        {
            return "Main";
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            Console.WriteLine("아무키나 눌러 시작");
            Console.ReadKey();
            SceneManager.LoadScene("VillageScene");
        }
    }
}

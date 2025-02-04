using RtanDungeon.Manager;
using RtanDungeon.Modle.Character.Player;
using RtanDungeon.Scenes;
using RtanDungeon.Utility;

namespace RtanDungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RegisterScenes();

            SceneManager.Init();
        }

        private static void RegisterScenes()
        {
            SceneManager.RegisterScene("MainScene", new MainScene());
            SceneManager.RegisterScene("VillageScene", new VillageScene());
            SceneManager.RegisterScene("DungeonScene", new DungeonScene());
        }
    }
}

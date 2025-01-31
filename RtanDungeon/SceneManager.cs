using RtanDungeon.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon
{
    public static class SceneManager
    {
        private static Dictionary<string, IScene> scenes = new Dictionary<string, IScene>();
        private static bool isGameQuit = false;
        private static IScene? currentScene;

        public static void Update(string[] args)
        {
            if (scenes.Count == 0) return;

            currentScene = scenes.First().Value;

            while (!isGameQuit)
            {
                currentScene.Main(args);
            }
        }

        public static void RegisterScene(string sceneName, IScene scene)
        {
            if(!scenes.ContainsKey(sceneName)) scenes.Add(sceneName, scene);
        }

        public static void LoadScene(string sceneName)
        {
            if (scenes.TryGetValue(sceneName, out var scene))
            {
                Console.Clear();
                currentScene = scene;
            }
            else new Exception("Can not found scene");
        }
    }
}

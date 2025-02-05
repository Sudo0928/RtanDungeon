using RtanDungeon.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Manager
{
    public static class SceneManager
    {
        private static Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();
        private static bool isGameQuit = false;
        private static Scene? currentScene;

        public static void Init()
        {
            string scene = scenes.First().Key;
            LoadScene(scene);
        }

        public static void Start()
        {
            currentScene.Start();
        }

        public static void Update()
        {
            if (scenes.Count == 0) return;

            while (!isGameQuit)
            {
                currentScene.Update();
            }
        }

        public static void RegisterScene(string sceneName, Scene scene)
        {
            if (!scenes.ContainsKey(sceneName)) scenes.Add(sceneName, scene);
        }

        public static void LoadScene(string sceneName)
        {
            if (scenes.TryGetValue(sceneName, out var scene))
            {
                Console.Clear();
                currentScene = scene;
                Start();
                Update();
            }
            else new Exception("Can not found scene");
        }

        public static void QuitGame()
        {
            isGameQuit = true;
        }
    }
}

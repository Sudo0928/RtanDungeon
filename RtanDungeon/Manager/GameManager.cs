using RtanDungeon.Modle;
using RtanDungeon.Modle.Character.Player;
using RtanDungeon.Modle.Items;
using RtanDungeon.Modle.Stat;
using RtanDungeon.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Manager
{
    public class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                    _instance.Init();
                }
                return _instance;
            }
        }

        public Player Player { get; private set; }

        public DataManager DataManager { get; private set; }

        public void Init()
        {
            DataManager = new DataManager();

            Player = new Player("Rtan", new EntityStat(100, 10, 5), Job.WARRIOR);
            Player.AddGold(99999999);
        }
    }
}

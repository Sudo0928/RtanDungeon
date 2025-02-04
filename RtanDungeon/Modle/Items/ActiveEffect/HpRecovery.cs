using RtanDungeon.Interface;
using RtanDungeon.Modle.Character.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle.Items.ActiveEffect
{
    public class HpRecovery : IActiveEffect
    {
        public HpRecovery(uint hpRecoveryAmount)
        {
            this.hpRecoveryAmount = hpRecoveryAmount;
        }

        private uint hpRecoveryAmount;

        public void Invoke(Player player)
        {
            player.Stat.AddHp(hpRecoveryAmount);
        }
    }
}

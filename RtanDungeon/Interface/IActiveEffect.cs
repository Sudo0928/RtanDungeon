using RtanDungeon.Modle.Character.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Interface
{
    public interface IActiveEffect
    {
        void Invoke(Player player);
    }
}

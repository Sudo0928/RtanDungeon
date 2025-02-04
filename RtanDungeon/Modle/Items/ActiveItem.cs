using RtanDungeon.Interface;
using RtanDungeon.Modle.Character.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Modle.Items
{
    public class ActiveItem : Item
    {
        public ActiveItem(string name, string description, List<IActiveEffect> effects) : base(name, description)
        {
            activeEffects = effects;
        }

        private List<IActiveEffect> activeEffects = new List<IActiveEffect>();

        public void AddEffect(IActiveEffect activeEffect)
        {
            activeEffects.Add(activeEffect);
        }

        public void UseItem(Player player)
        {
            foreach (var effect in activeEffects)
            {
                effect.Invoke(player);
            }
        }

        public override Item Clone()
        {
            return new ActiveItem(name, description, activeEffects);
        }
    }
}

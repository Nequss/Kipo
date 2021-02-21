using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class AxeKick : Ability
    {
        public AxeKick()
        {
            name = "Axe Kick";
            description = "Slow but strong!";
            price = 1000;
        }
    }
}
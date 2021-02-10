using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Tools
{
    [Serializable]
    class Camera : Item
    {
        public Camera()
        {
            type = Type.Tool;
            price = 200;
            name = "Camera";
            description = "Take some pretty pictures and sell them";
        }
    }
}
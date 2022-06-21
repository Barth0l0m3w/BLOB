using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class SquidEdge : Sprite
    {
        public SquidEdge() : base("images/Horizontal_Border_Vine_Placeholder.png")
        {
            SetXY(0, 700);
            alpha = 0f;
        }
    }
}

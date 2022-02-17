using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Button : Sprite
    {
        public Button(float CX, float CY, string image) : base(image)
        {
            x = CX;
            y = CY;
            alpha = 0.7f;
        }
    }
}

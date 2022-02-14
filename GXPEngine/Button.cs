using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Button : Sprite 
    {
        public Button(float CX, float CY) : base("startButton.png")
        {
            x = CX;
            y = CY;


        }
    }
}

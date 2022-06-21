using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

    public class WallTop : Sprite
    {
    public WallTop(float posX, float posY) : base("images/Horizontal_Border_Vine_Placeholder.png") 
    {
        SetOrigin(this.width / 2, this.height / 2);
        this.x = posX;
        this.y = posY;
        alpha = 0f;

    }


    }


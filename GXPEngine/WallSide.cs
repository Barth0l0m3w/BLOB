using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;



    public class WallSide: Sprite
    {
    public WallSide(float posX, float posY) : base("images/Verticle_Border_Vine_Placeholder.png.png") 
        {
        SetOrigin(this.width / 2, this.height / 2);
        this.x = posX;
        this.y = posY;
        alpha = 0;
    }

    }


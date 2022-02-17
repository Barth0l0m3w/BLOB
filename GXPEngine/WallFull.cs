using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class WallFull : SpriteBatch
{
    public WallFull() : base("Horizontal_Border_Vine_Placeholder.png", "Verticle_Border_Vine_Placeholder.png.png")
    {

        Sprite wallSideLeft = new Sprite("Verticle_Border_Vine_Placeholder.png.png");
        AddChild(wallSideLeft);
        wallSideLeft.x = wallSideLeft.width / 2;
        wallSideLeft.y = 0;
        wallSideLeft.alpha = 0f;

        Sprite wallSideRight = new Sprite("Verticle_Border_Vine_Placeholder.png.png");
        AddChild(wallSideRight);
        wallSideRight.x = game.width - wallSideRight.width;
        wallSideRight.y = 0;
        wallSideRight.alpha = 0f;

        Sprite wallSideUp = new Sprite("Horizontal_Border_Vine_Placeholder.png");
        AddChild(wallSideUp);
        wallSideUp.x = 0;
        wallSideUp.y = wallSideUp.height / 2;
        wallSideUp.alpha = 0f;

        //Freeze();

    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Enemy : Sprite
{
    private float radians;
    private float radius;
    

    public Enemy():base ("crab.png")
    {
        //SetOrigin(width / 2, height / 2);
        radians = 0;
        x = (game.width - this.width) / 2;
        y = (game.height - this.height) / 2;
        SetScaleXY(0.3f, 0.3f);
    }

    void Update()
    {
        radius = 100;
        radians += 0.05f;

        float myX = radius * Mathf.Cos(radians);
        x = myX;
        x += game.width / 2;
    }
}
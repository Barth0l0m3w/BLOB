using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Enemy : Sprite
{
    private float radians;
    private float radius;
    private float speed = 0.2f;
    

    public Enemy():base ("crab.png")
    {
        width *= (int)0.5f;
        height *= (int)1;

        SetOrigin(width / 2, height / 2);
        radians = 0;
        SetXY(Utils.Random(width, game.width), 20);//Utils.Random(-300, 0));
        SetScaleXY(0.1f, 0.1f);
    }

    void Update()
    {
        radius = 100;
        radians += 0.02f;
        y += speed;

        float myX = radius * Mathf.Cos(radians);
        x = myX;
        x += game.width / 2;
    }
}
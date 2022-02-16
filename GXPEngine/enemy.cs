using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Enemy : Sprite
{
    private float radians;
    private float radius;
    private float speed = 1f;


    public Enemy() : base("squid.png")
    {
        Respawn();
        SetOrigin(width / 2, height / 2);
        radians = 0;
        SetXY(Utils.Random(100, game.width - 100), Utils.Random(-200, 0));
    }

    void Update()
    {
        radius = 1;
        radians += 0.02f;
        y += speed;

        float myX = radius * Mathf.Cos(radians);
        x += myX;

        this.rotation += 1;

        if (y > game.height + height)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        SetXY(Utils.Random(100, game.width - 100), Utils.Random(-200, 0));
    }

    void OnCollision(GameObject other)
    {
        if (other is Blob)
        {
            //  Time.deltaTime
            //
            LateDestroy();
            //respawn();
        }
    }
}
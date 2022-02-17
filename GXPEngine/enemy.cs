using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Enemy : AnimationSprite
{
    private float radians;
    private float radius;
    private float speed = 1f;

    private bool reachBorder = false;

    private bool low = false;

    public Enemy() : base("Squid_Spritesheet.png", 6, 1)
    {
        Respawn();
        SetOrigin(width / 2, height / 2);
        radians = 0;
        SetXY(Utils.Random(100, game.width - 100), Utils.Random(-200, 0));
        rotation = 180;
    }
    public int GetBabies()
    {
        return ((MyGame)game).amountBabies;
    }

    void Update()
    {
        Animate(0.3f);
        
        radius = 1;
        radians += 0.02f;
        y += speed;

        float myX = radius * Mathf.Cos(radians);
        x += myX;

        //this.rotation += 1;

        if (y > game.height + height)
        {
            LateDestroy();
        }
    }

    void Respawn()
    {
        SetXY(Utils.Random(100, game.width - 100), Utils.Random(-300, 0));
    }

    void OnCollision(GameObject other)
    {
        if (other is Blob)
        {
            LateDestroy();
        }
        if (other is SquidEdge)
        {
            if(!reachBorder)
            {
                reachBorder = true;
                ((MyGame)game).amountBabies = ((MyGame)game).amountBabies -1;
            }
        }
    }
}
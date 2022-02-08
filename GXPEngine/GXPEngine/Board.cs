using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;


public class Board : Sprite
{
    public float speedX = 0f;
    //float speedY = 0f;
    public Board() : base("square.png")
    {
        this.x = game.width / 2;
        this.y = game.height - 100;

    }

    void Update()
    {
        applyWalking();
        //applyGravity();

        if (x > 800 - width)
        {
            x = 799 - width;
        }

        if (x < 0)
        {
            x = 1;
        }

    }

    private void applyWalking()
    {
        if (Input.GetKey(Key.LEFT))
        {
            speedX -= 1.0f;

        }
        if (Input.GetKey(Key.RIGHT))
        {
            speedX += 1.0f;

        }
        x += speedX;
        speedX *= 0.9f;
    }
    void OnCollision(GameObject other)
    {



    }
}


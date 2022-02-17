using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;


public class Board : Sprite
{

    public float speedX = 0f;

    public Board() : base("platform.png")
    {
        SetOrigin(height / 2, width / 2);
        this.x = game.width / 2;
        this.y = game.height;
    }

    void Update()
    {
        applyWalking();

        if (x > game.width - width)
        {
            x = game.width - width;
        }

        if (x < 0)
        {
            x = 1;
        }
    }

    private void applyWalking()
    {
        if (Input.GetKeyDown(Key.A))
        {
            speedX -= 0.8f;
        }
        if (Input.GetKeyDown(Key.D))
        {
            speedX += 0.8f;
        }
        x += speedX; 
        speedX *= 0.9f;
    }
}


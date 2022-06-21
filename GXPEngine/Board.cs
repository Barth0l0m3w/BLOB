using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;


public class Board : Sprite
{
    public float speedX = 0f;

    public Board() : base("images/platform.png")
    {
        SetOrigin(width / 2, height / 2);

        this.x = game.width / 2;

        this.y = game.height - 100;
    }

    void Update()
    {
        applyWalking();
    }

    private void applyWalking()
    {
        if (Input.GetKey(Key.A))
        {
            speedX -= 2.4f;
        }
        if (Input.GetKey(Key.D))
        {
            speedX += 2.4f;
        }

        MoveUntilCollision(speedX, 0);
        speedX *= 0.9f;
    }
}


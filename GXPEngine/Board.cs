using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;


    public class Board: Sprite
    {

    public float speedX = 0f;

    public Board() : base("platform.png")
    {
        SetOrigin(width / 2 , height / 2);
        this.x = game.width / 2;
        this.y = game.height - 100;

    }

    void Update()
    {
        applyWalking();

        //applyGravity();
        /*
        if (x > game.width - width)
        {
            x = game.width - width;
        }

        if (x < 0)
        {
            x = 1;
        }
        */
    }

    private void applyWalking()
    {
        if (Input.GetKey(Key.LEFT))
        {
            speedX -= 0.3f;
        }
        if (Input.GetKey(Key.RIGHT))
        {
            speedX += 0.3f;
        }
        MoveUntilCollision(speedX, 0);
        speedX *= 0.9f;
    }
    void OnCollision(GameObject other)
    {
    
    }
}


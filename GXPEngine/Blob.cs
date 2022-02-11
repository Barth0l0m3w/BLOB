using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

    public class Blob : Sprite
    {
    float speedX = 0f;
    float speedY = 0f;

    float dirX = 1.0f;
    float dirY = 1.0f;

    Board board;
    public Blob() : base("blob.png")
    {
        Respawn();

    }
    void Update()
    {
        StartGame();
        Bounce();

        x += speedX * dirX;
        y += speedY * dirY;

        
    }

    private void StartGame() {
        if (Input.GetKey(Key.SPACE))
        {
            speedX = Utils.Random(-2, 2.1f);
            speedY = 2.0f;

        }
    }

    void OnCollision(GameObject other)
    {
        if (other is Board) {
            dirX *= -1;
            dirY *= -1;
        }
        if (other is Enemy)
        {
            dirX *= -1;
            dirY *= -1;
            Console.WriteLine("hit");
        }
    }

    void Respawn()
    {
        x = (game.width - this.width) / 2;
        y = (game.height - this.height) / 2;
        speedX = 0;
        speedY = 0;
    }

    void Bounce() {
        if (y < 0 - height)
        {
            dirY *= -1;
        }

        if (y > game.height + height)
        {
            Respawn();
        }

        if (x < 0 - width / 2)
        {
            dirX *= -1;
        }

        if (y > game.width + width)
        {
            dirX *= -1;
        }

    }

}


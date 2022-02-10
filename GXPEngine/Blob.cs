using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

    public class Blob : Sprite
    {
    float speedX = 0f;
    float speedY = 0f;
    Board board;
    public Blob() : base("circle.png")
    {
        Respawn();

    }
    void Update()
    {
        StartGame();
        y += speedY;

        if (y < 0 - height)
        {
            speedY *= -1;
        }

        if (y > game.height + height)
        {
            Respawn();
        }
    }

    private void StartGame() {
        if (Input.GetKey(Key.SPACE))
        {
            speedY = 5.0f;

        }
    }

    void OnCollision(GameObject other)
    {
        if (other is Board) {
            //speedX = board.speedX;
            speedY *= -1;
        }
    }

    void Respawn()
    {
        x = (game.width - this.width) / 2;
        y = (game.height - this.height) / 2;
        speedY = 0;
    }

}


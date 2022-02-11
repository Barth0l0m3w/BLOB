using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

    public class Blob : AnimationSprite
    {
    public bool collide = false;

    float speedX = 0f;
    float speedY = 0f;
    Board board;
    public Blob() : base("Blob_Spritesheet.png", 7, 1)
    {
        SetOrigin(height / 2, width / 2);
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
        AnimateCharacter();
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
            collide = true;
            //delta time timer that switches the collide off when done 
        } else
        {
            
        }
    }

    void Respawn()
    {
        x = (game.width - this.width) / 2;
        y = (game.height - this.height) / 2;
        speedY = 0;
    }

    void AnimateCharacter()
    {

        if (collide == true)
        {
            SetCycle(1, 7);
        }
        else
        {
            SetCycle(0, 1);

        }
        Animate(0.2f);
    }
}


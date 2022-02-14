using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

    public class Blob : AnimationSprite
    {
    public bool collide = false;

    //float speedX = 0f;
    float speedY = 0f;
    //Board board;

    private float timer = 1.4f;
    private float waitTime = 0.0f;
    //private float animTimer = 0.0f;
    //private bool timerDone = false;

    const int NORMAL = 0;
    const int BOUNCING = 1;
    int currentState = NORMAL;
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
        TimerCycle();

        timer += Time.deltaTime;
        if (collide)
        { 
            if (timer > waitTime)
            {
                timer = timer - waitTime;
                collide = false;
                //timerDone = true;
            }
        }
    }

    private void StartGame() {
        if (Input.GetKey(Key.SPACE))
        {
            speedY = 1.0f;
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
        switch (currentState)
        {
            case BOUNCING:
            SetCycle(1, 7);
                Animate(0.2f);
                break;
            case NORMAL:
            SetCycle(0, 1);
                Animate(0.2f);
                break;
        }
    }

    void TimerCycle()
    {
        if (collide)
        {
            currentState = BOUNCING;
        } else
        {
            currentState = NORMAL;
        }
    } 
}


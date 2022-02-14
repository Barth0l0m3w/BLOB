using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

    public class Blob : AnimationSprite
    {
    public bool hasColided;

    //float speedX = 0f;
    float speedY = 0f;
    

    private float timer = 0;
    private float animTimer = 0;
    private float waitTime = 0.4f;
    

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

        if (y < 0)
        {
            speedY *= -1;
        }

        if (y > game.height - height)
        {
            Respawn();
        }

        AnimateCharacter();
        TimerCycle();

        timer += Time.deltaTime / 1000.0f;
        Console.WriteLine(animTimer);
        if (hasColided)
        {
            animTimer += Time.deltaTime / 1000.0f;
            if (animTimer > waitTime)
            {
                animTimer = 0;
                hasColided = false;
                
            }
        }
    }

    private void StartGame() {
        if (Input.GetKey(Key.SPACE))
        {
            speedY = 4.0f;
        }
    }

    void OnCollision(GameObject other)
    {
        if (other is Board) {
            hasColided = true;
            speedY *= -1;
            
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
        if (hasColided)
        {
            currentState = BOUNCING;
        } else
        {
            currentState = NORMAL;
        }
    } 
}


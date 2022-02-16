using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Blob : AnimationSprite
{
    private bool hasColided;

    float speedX = 0f;
    float speedY = 0f;

    float dirX = 1.0f;
    float dirY = 1.0f;

    private float timer = 0;
    private float animTimer = 0;
    private float waitTime = 0.4f;

    const int NORMAL = 0;
    const int BOUNCING = 1;
    int currentState = NORMAL;

    public int _score;

    public Blob() : base("Blob_Spritesheet.png", 7, 1)
    {
        SetOrigin(height / 2, width / 2);
        Respawn();

        _score = 0;

    }

    public int GetScore()
    {
        return _score;
    }

 
    void Update()
    {
        StartGame();
        Bounce();

        x += speedX * dirX;
        y += speedY * dirY;

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

    private void StartGame()
    {
        if (Input.GetKey(Key.SPACE))
        {
            speedX = Utils.Random(-2, 2.1f);
            speedY = 4.0f;
        }
    }

    void OnCollision(GameObject other)
    {
        if (other is Board)
        {
            dirX *= -1;
            dirY *= -1;
            hasColided = true;
        }
        if (other is Enemy)
        {
            dirX *= -1;
            dirY *= -1;
            hasColided = true;
            _score = _score + 1;
        }
    }

    void Respawn()
    {
        x = (game.width - this.width) / 2;
        y = (game.height - this.height) / 2;
        speedX = 0;
        speedY = 0;
    }

    void Bounce()
    {
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

        if (x > game.width + width)
        {
            dirX *= -1;
        }
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
        }
        else
        {
            currentState = NORMAL;
        }
    }
}


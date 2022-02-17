using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;


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
    const float SPEED = 4.0f;
    int currentState = NORMAL;

    public int _score;
    private bool reachBorder = false;

    Board board = new Board();

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

        Move(speedX * dirX, 0);
        Move(0, speedY * dirY);

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
        if (Input.GetKeyDown(Key.SPACE))
        {
            speedX = Utils.Random(-1 * SPEED, SPEED);

            speedY = SPEED;

            dirX = 1.0f;
            dirY = 1.0f;
        }
    }

    void OnCollision(GameObject other)
    {
        var col = collider.GetCollisionInfo(other.collider);
        //Console.WriteLine("Collision normal{0}:", col.normal);

        if (other is WallSide || other is WallTop)
        {
            //Console.WriteLine("Console normal wall:", col.normal.x, col.normal.y);

            if (col.normal.x < 0.5f && col.normal.y < 0.5f)
            {
                if (col.normal.x > col.normal.y)
                {
                    dirY *= -1;
                }
                if (col.normal.x < col.normal.y)
                {
                    dirX *= -1;
                }
            }
        }

        if (other is Enemy)
        {
            hasColided = true;
            currentState = 
            _score += 100;
            if (col.normal.x < 0.5f && col.normal.y < 0.5f)
            {
                if (col.normal.x > col.normal.y)
                {
                    dirY *= -1;
                }
                if (col.normal.x < col.normal.y)
                {
                    dirX *= -1;
                }
            }

            else
            {
                dirX *= -1;
                dirY *= -1;
            }
        }

        if (other is SquidEdge)
        {
            if (!reachBorder)
            {
                reachBorder = true;
                ((MyGame)game).amountBabies = ((MyGame)game).amountBabies - 1;
            }
        }

        if (other is Board)
        {
            hasColided = true;
            board = other as Board;
            float xOffset = Mathf.Abs((board.x - this.x)) / 160.0f;
            speedX = SPEED + xOffset;
            speedY = SPEED - xOffset;
            if (board.x > this.x)
            {
                dirX = -1;
            }
            if (board.x < this.x)
            {
                dirX = 1;
            }
            dirY = -1;
        }
    }

    void Respawn()
    {
        x = (game.width - this.width) / 2;
        y = (game.height - this.height) / 2;
        speedX = 0;
        speedY = 0;

        reachBorder = false;
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


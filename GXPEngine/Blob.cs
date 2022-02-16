using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;


    public class Blob : AnimationSprite
{
    public bool hasColided;

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

    public Blob() : base("Blob_Spritesheet.png", 7, 1)
    {
        SetOrigin(height / 2, width / 2);
        Respawn();
        
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

    private void StartGame() 
    {
        if (Input.GetKey(Key.SPACE))
        {
            speedX = Utils.Random(-2, 2.1f);

            speedY = 2.0f;

            dirX = 1.0f;
            dirY = 1.0f;
        }
    }

    void OnCollision(GameObject other)
    {
        var col = collider.GetCollisionInfo(other.collider);
        //Console.WriteLine("Collision normal{0}:", col.normal);
        
        if (other is WallSide || other is WallTop) { 
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
            else{
                dirX *= -1;
                dirY *= -1;
            }
                //Console.WriteLine("Console normal enemy:", col.normal.x, col.normal.y);
        }
        
        if (other is Board)
        {
            
            board = other as Board;
            float xOffset = Mathf.Abs((board.x - this.x)) / 160.0f;      //214.0f;
            speedX = 2 + xOffset;
            speedY = 2 - xOffset;
            if (board.x > this.x){
               dirX = -1;
            }
            if (board.x < this.x)
            {
                dirX = 1;
            }

            /*
            Console.WriteLine(board.x - this.x);
            Console.WriteLine(board.width / 2 + this.width);
            Console.WriteLine("X offest is: {0}", xOffset);
            */

            //dirX *= -1;
            dirY = -1;
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
        } else
        {
            currentState = NORMAL;
        }
    } 
}


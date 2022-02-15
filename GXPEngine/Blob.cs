using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;

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
        //Bounce();

        x += speedX * dirX;
        y += speedY * dirY;

        

        if (y > game.height - height)
        {
            Respawn();
        }

        

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
        var col = collider.GetCollisionInfo(other.collider);
        Console.WriteLine("Collision normal{0}:", col.normal);
        
        if (other is WallSide || other is WallTop) { 
            Console.WriteLine("Console normal wall:", col.normal.x, col.normal.y);
            
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
                
                Console.WriteLine("Console normal enemy:", col.normal.x, col.normal.y);

        }
        if (other is Board)
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
            else
            {
                dirX *= -1;
                dirY *= -1;
            }
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

        if (x > game.width - width)
        {
            dirX *= -1;
        }

    }

}


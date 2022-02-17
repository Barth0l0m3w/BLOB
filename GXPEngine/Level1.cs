using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Level1 : GameObject
    {
        //int lvlNMB;

        public List<Enemy> enemies;
        public List<Enemy> toAddEnemy = new List<Enemy>();

        private float timer = 0;
        private float animTimer = 0;
        private float waitTime = 2;

        public Level1()
        {
            enemies = new List<Enemy>();
            AnimationSprite spriteSheet = new AnimationSprite("background_spritesheet.png ", 4, 1, 1, false, false);
            AddChild(spriteSheet);
            spriteSheet.Animate(0.4f);

            //Enemy enemy = new Enemy();
            //AddChild(enemy);

            WallSide wallLeft = new WallSide(0, game.height / 2);
            AddChild(wallLeft);

            WallSide wallRight = new WallSide(game.width, game.height / 2);
            AddChild(wallRight);

            WallTop wallTop = new WallTop(game.width / 2, 0);
            AddChild(wallTop);

            Board board = new Board();
            AddChild(board);

            Blob blob = new Blob();
            AddChild(blob);

        }

        private void EnemySpawn()
        {

            Enemy enemie = new Enemy();
            AddChild(enemie);
            enemies.Add(enemie);

        }

        void Update()
        {
            Console.WriteLine(enemies.Count);
            

            timer += Time.deltaTime / 1000.0f;
            //Console.WriteLine(animTimer);

            animTimer += Time.deltaTime / 1000.0f;
            if (animTimer >= waitTime)
            {
                if (enemies.Count < 2)
                {
                    EnemySpawn();
                }
                //Console.WriteLine("now");
                animTimer = 0;
            }

        }
    }
}

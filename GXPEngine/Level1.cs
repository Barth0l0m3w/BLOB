using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Level1 : GameObject
    {
        public List<Enemy> enemies;
        public List<Enemy> toAddEnemy = new List<Enemy>();

        private float timer = 0;
        private float animTimer = 0;
        private float waitTime = 10;

        public Level1()
        {
            enemies = new List<Enemy>();

            AnimationSprite spriteSheet = new AnimationSprite("background_spritesheet.png ", 4, 1, 1, false, false);

            AddChild(spriteSheet);
            spriteSheet.Animate(0.4f);

            Babies babies = new Babies();
            AddChild(babies);
            Babies babies2 = new Babies();
            AddChild(babies2);
            Babies babies3 = new Babies();
            AddChild(babies3);
            Babies babies4 = new Babies();
            AddChild(babies4);
            Babies babies5 = new Babies();
            AddChild(babies5);
            Babies babies6 = new Babies();
            AddChild(babies6);


            SquidEdge squidEdge = new SquidEdge();
            AddChild(squidEdge);

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

            Enemy enemy = new Enemy();

            HUD hud;
            hud = new HUD(blob, enemy);
            AddChild(hud);

            EnemySpawn();
            EnemySpawn();
        }

        private void EnemySpawn()
        {
            Enemy enemie = new Enemy();
            AddChild(enemie);
            enemies.Add(enemie);
        }

        void Update()
        {
            timer += Time.deltaTime / 1000.0f;

            animTimer += Time.deltaTime / 1000.0f;
            if (animTimer >= waitTime)
            {
                if (enemies.Count < 9999)
                {
                    EnemySpawn();
                    EnemySpawn();
                }
                animTimer = 0;
            }
        }
    }
}

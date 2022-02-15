using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Level1 : GameObject
    {
		int lvlNMB;

		public List<Enemy> enemies = new List<Enemy>();
		public List<Enemy> toAddEnemy = new List<Enemy>();

		public Level1(int levelNMB)
		{
			lvlNMB = levelNMB;

			Sprite sprite = new Sprite("main_background.png ");
			AddChild(sprite);

			Board board = new Board();
			AddChild(board);

			Blob blob = new Blob();
			AddChild(blob);

			Enemy enemy = new Enemy();
			AddChild(enemy);

		}

		private void EnemySpawn()
        {
			for (int i = 0; i < 5; ++i)
			{
				Enemy enemies = new Enemy();
				AddChild(enemies);
			}
		}
	}
}

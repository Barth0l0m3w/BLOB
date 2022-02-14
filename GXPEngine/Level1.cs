using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Level1 : GameObject
    {
		int lvlNMB;

		public Level1(int levelNMB)
        {
			lvlNMB = levelNMB;
			StartLevel();
        }

		public void StartLevel()
        {
			Sprite sprite = new Sprite("main_background.png ");
			AddChild(sprite);

			Board board = new Board();
			AddChild(board);

			Blob blob = new Blob();
			AddChild(blob);

			Enemy enemy = new Enemy();
			AddChild(enemy);


			for (int i = 0; i < 5; ++i)
			{
				Enemy enemies = new Enemy();
				AddChild(enemies);
			}
		}
	}
}

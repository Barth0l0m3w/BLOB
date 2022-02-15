using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	public class LevelHighScore : GameObject
	{
		int lvlNMB;

		public LevelHighScore(int levelNMB)
		{
			lvlNMB = levelNMB;

			Sprite sprite = new Sprite("homescreen.png");
			AddChild(sprite);
		}
	}
}

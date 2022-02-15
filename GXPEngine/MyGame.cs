using System;									
using GXPEngine;                                
using System.Drawing;
using System.Collections.Generic;

public class MyGame : Game
{
	//float enemies = 0;

	public List<Enemy> enemies = new List<Enemy>();
	public List<Enemy> toAddEnemy = new List<Enemy>();
	public MyGame() : base(1366, 768, false)		
	{

		
		Sprite sprite = new Sprite("main_background.png ", false, false);
		AddChild(sprite);

		WallSide wallLeft = new WallSide(0, game.height/2);
		AddChild(wallLeft);

		WallSide wallRight = new WallSide(game.width, game.height / 2);
		AddChild(wallRight);

		WallTop wallTop = new WallTop(game.width/2, 0);
		AddChild(wallTop);

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

	void Update()

	{

	}

	static void Main()
	{
		new MyGame().Start();
	}
}
using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;							// System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;

public class MyGame : Game
{
	//float enemies = 0;

	public List<Enemy> enemies = new List<Enemy>();
	public List<Enemy> toAddEnemy = new List<Enemy>();
	public MyGame() : base(1366, 768, false, false)	
	{
		targetFps = 60;

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

	void Update()

	{

	}

	static void Main()
	{
		new MyGame().Start();
	}
}
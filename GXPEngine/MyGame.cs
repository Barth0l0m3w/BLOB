using System;									
using GXPEngine;                                
using System.Drawing;
using System.Collections.Generic;

public class MyGame : Game
{

	public MyGame() : base(1366, 768, false, false)	
	{
		targetFps = 60;

		SceneManager sceneManager = new SceneManager();
		AddChild(sceneManager);

		sceneManager.loadLevel("MainMenu");
	}

	void Update()

	{

	}

	static void Main()
	{
		new MyGame().Start();
	}
}
using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;							// System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game
{
	public MyGame() : base(800, 600, false)		// Create a window that's 800x600 and NOT fullscreen
	{
		Board board = new Board();
		AddChild(board);

		Blob blob = new Blob();
		AddChild(blob);
	}

	void Update()
	{
		// Empty
	}

	static void Main()
	{
		new MyGame().Start();
	}
}
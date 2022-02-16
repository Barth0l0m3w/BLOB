using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;							// System.Drawing contains drawing tools such as Color definitions
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
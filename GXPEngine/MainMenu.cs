using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
     public class MainMenu : GameObject
    {
        Button startButton;
        public MainMenu()
        {
            Sprite backGround = new Sprite("homescreen.png");
            AddChild(backGround);

            startButton = new Button(0, 0);
            AddChild(startButton);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (startButton.HitTestPoint(Input.mouseX, Input.mouseY))
                {
                    StartLevel1();
                    HideMenu();
                    startButton.Destroy();
                }
            }
        }

        void HideMenu()
        {
            startButton.visible = false;
        }

        public void StartLevel1()
        {
            Level1 level1 = new Level1(1);
            AddChild(level1);
        }
    }
}

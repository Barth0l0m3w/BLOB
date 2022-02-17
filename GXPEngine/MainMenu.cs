using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class MainMenu : GameObject
    {
        Button startButton;
        Button highScore;
        private int buttonSelected = 1;

        public MainMenu()
        {
            Sprite backGround = new Sprite("homescreen.png");
            AddChild(backGround);

            startButton = new Button(0, 0, "startButton.png");
            AddChild(startButton);

            highScore = new Button(0, 0, "highScore.png");
            AddChild(highScore);
        }

        void Update()
        {
            SelectNumber();

            if (buttonSelected == 1)
            {
                startButton.alpha = 1f;
                highScore.alpha = 0.7f;

                if (Input.GetKeyDown(Key.SPACE))
                {
                    SceneManager.Instance.loadLevel("Level1");
                }
            }
            if (buttonSelected == 2)
            {
                highScore.alpha = 1f;
                startButton.alpha = 0.7f;

                if (Input.GetKeyDown(Key.SPACE))
                {
                    SceneManager.Instance.loadLevel("LevelHighScore");
                }
            }
            if (buttonSelected == 0)
            {
                highScore.alpha = 0.7f;
                startButton.alpha = 0.7f;
            }
        }

        private void SelectNumber()
        {
            if (Input.GetKeyDown(Key.D))
            {
                buttonSelected += 1;
            }

            if (Input.GetKeyUp(Key.A))
            {
                buttonSelected -= 1;
            }

            if (buttonSelected <= 1)

            {
                buttonSelected = 1;
            }

            if (buttonSelected >= 2)
            {
                buttonSelected = 2;
            }
        }
    }
}

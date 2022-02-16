using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class LevelHighScore : GameObject
    {
        Button backButton;
        private int buttonSelected = 0;

        public LevelHighScore()
        {
            //lvlNMB = levelNMB;

            Sprite sprite = new Sprite("highScoreBackGround.png");
            AddChild(sprite);

            backButton = new Button(0, 0, "backButton.png");
            AddChild(backButton);


        }

        void Update()
        {
            SelectNumber();

            if (buttonSelected == 1)
            {
                backButton.alpha = 1f;

                if (Input.GetKeyUp(Key.SPACE))
                {
                    //HideMenu();
                    SceneManager.Instance.loadLevel("MainMenu");
                }
            }

            if (buttonSelected == 0)
            {
                backButton.alpha = 0.7f;
            }
        }

        private void SelectNumber()
        {
            if (Input.GetKeyUp(Key.RIGHT))
            {
                buttonSelected += 1;
                //Console.WriteLine("right clicked");
            }

            if (Input.GetKeyUp(Key.LEFT))
            {
                buttonSelected -= 1;
            }

            if (buttonSelected <= 0)
            {
                buttonSelected = 0;
            }

            if (buttonSelected >= 1)
            {
                buttonSelected = 1;
            }
        }
    }
}

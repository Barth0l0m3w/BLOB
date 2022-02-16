using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GXPEngine
{
    public class LevelHighScore : GameObject
    {
        Button backButton;
        private int buttonSelected = 0;
        private Font luckyGuy;
        private Font lucky;

        private EasyDraw title;
        private EasyDraw lines;

        public LevelHighScore()
        {
            Sprite sprite = new Sprite("highScoreBackGround.png");
            AddChild(sprite);

            backButton = new Button(0, 0, "backButton.png");
            AddChild(backButton);

            title = new EasyDraw(1366, 768);
            luckyGuy = Utils.LoadFont("LuckiestGuy.ttf", 40);
            title.TextFont(luckyGuy);
            title.Fill(Color.White);
            title.TextAlign(CenterMode.Center, CenterMode.Min);
            title.SetXY(0, 200);
            title.Text("HIGHSCORE:");
            AddChild(title);

            lines = new EasyDraw(1366, 768);
            lucky = Utils.LoadFont("LuckiestGuy.ttf", 32);
            lines.TextFont(lucky);
            lines.Fill(Color.White);
            lines.TextAlign(CenterMode.Center, CenterMode.Min);
            lines.SetXY(0, 300);
            lines.Text("name:   3400" + "name:   3400" + "name:   3400" + "name:   3400");


            AddChild(lines);
        }

        void Update()
        {
            SelectNumber();

            if (buttonSelected == 1)
            {
                backButton.alpha = 1f;

                if (Input.GetKeyUp(Key.SPACE))
                {
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

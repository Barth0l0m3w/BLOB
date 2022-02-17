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
        private int num = 0;

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
            title.SetXY(0, 100);
            title.Text("HIGHSCORE:");
            AddChild(title);

            lines = new EasyDraw(1366, 768);

            string[] hs = {"11. raul 300", "10. timon 800", "9. Jan 1000", "8. zehra 1100", "7. Salvador 1400", "6. delano 1600", "5. nathan 2100", "4. luniyo 2200", "3. kamila 2400", "2. nathalie 2700", "1. mario 5100" };
            for (int i = hs.Length; i > 0; i--)
            {
                lucky = Utils.LoadFont("LuckiestGuy.ttf", 25);
                lines.TextFont(lucky);
                lines.Fill(Color.White);
                lines.TextAlign(CenterMode.Min, CenterMode.Min);
                lines.SetXY(0, 200);
                lines.Text(hs[i - 1], 550, 10 + 45 * num);
                num++;
            }
            AddChild(lines);
        }

        void Update()
        {
            SelectNumber();

            if (buttonSelected == 1)
            {
                backButton.alpha = 1f;

                if (Input.GetKeyDown(Key.SPACE))
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
            if (Input.GetKeyDown(Key.D))
            {
                buttonSelected += 1;
            }

            if (Input.GetKeyDown(Key.A))
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

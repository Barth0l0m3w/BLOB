using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GXPEngine
{
    public class Death : GameObject
    {
        Button _backButton;
        private int buttonSelected = 0;

        private Font luckyGuy;
        private EasyDraw title;

        public Death()
        {
            Sprite sprite = new Sprite("endingWithoutTitle.png");
            AddChild(sprite); 

            _backButton = new Button(0, 50, "endingMainButton.png");
            AddChild(_backButton);

            title = new EasyDraw(1366, 768);
            luckyGuy = Utils.LoadFont("LuckiestGuy.ttf", 40);
            title.TextFont(luckyGuy);
            title.Fill(Color.White);
            title.TextAlign(CenterMode.Center, CenterMode.Min);
            title.SetXY(0, 100);
            title.Text("DEATH");
            AddChild(title);
        }

        void Update()
        {
            SelectNumber();

            if (buttonSelected == 1)
            {
                _backButton.alpha = 1f;

                if (Input.GetKeyDown(Key.SPACE))
                {
                    SceneManager.Instance.loadLevel("MainMenu");
                }
            }

            if (buttonSelected == 0)
            {
                _backButton.alpha = 0.7f;
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

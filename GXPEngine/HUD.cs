using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Drawing.Text;


namespace GXPEngine
{
    public class HUD : Canvas
    {
        private Blob _blob;
        private Enemy _enemy;

        public HUD(Blob blob, Enemy enemy) : base(1366, 768, false)
        {
            _blob = blob;
            _enemy = enemy;
        }

        void Update()
        {
            graphics.Clear(Color.Empty);
            graphics.DrawString("score:" + _blob.GetScore(), Utils.LoadFont("LuckiestGuy.ttf", 32), Brushes.White, 5, 720);
            graphics.DrawString("health:" + _enemy.GetBabies(), Utils.LoadFont("LuckiestGuy.ttf", 32), Brushes.White, 1150, 720);
        }
    }
}

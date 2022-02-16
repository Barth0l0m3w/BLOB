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

        public HUD(Blob blob) : base(1366, 768, false)
        {
            _blob = blob;
            //Utils.LoadFont("LuckiestGuy.ttf", 32);
        }

        void Update()
        {
            graphics.Clear(Color.Empty);
            graphics.DrawString("score:" + _blob.GetScore(), Utils.LoadFont("LuckiestGuy.ttf", 32), Brushes.White, 0, 720); 
        }
    }
}

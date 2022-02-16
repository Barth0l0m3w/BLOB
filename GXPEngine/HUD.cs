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

        private EasyDraw _score;
        private EasyDraw healthUI;


        public HUD(Blob blob) : base(1366, 768, false)
        {
            _blob = blob;
        }

        void Update()
        {
            graphics.Clear(Color.Empty);
            graphics.DrawString("score:" + _blob.GetScore(), SystemFonts.DefaultFont, Brushes.White, 0, 0); 
        }
    }
}

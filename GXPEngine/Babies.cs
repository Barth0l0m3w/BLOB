using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Babies : AnimationSprite
    {
        public Babies() : base("Blob_Spritesheet.png", 7, 1)
        {
            SetScaleXY(0.75f, 0.75f);
            SetXY(Utils.Random(game.width / 3, game.width / 3 + 500), 700);
        }

        void Update()
        {
            Animate(0.4f);
        }
    }
}

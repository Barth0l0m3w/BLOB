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
            Animate(0.04f);
            SetXY(Utils.Random(game.width/3, game.width/3 +500), 700);
        }
    }
}

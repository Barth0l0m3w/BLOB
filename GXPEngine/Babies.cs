using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Babies : AnimationSprite
    {
        private float radians;
        private float radius;
        private float speed = 0.35f;

        public Babies() : base("Blob_Spritesheet.png", 7, 1)
        {
            SetScaleXY(0.75f, 0.75f);
            SetXY(Utils.Random(game.width / 3 - 50, game.width / 3 + 400), 700);
        }

        void Update()
        {
            Animate(0.4f);

            radius = (Utils.Random(0.8f, 1.2f));
            radians += 0.025f;

            float myX = radius * Mathf.Cos(radians);
            x += myX;
        }
    }
}

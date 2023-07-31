using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Explosion : Drawable
    {
        float Timer;
        public Explosion()
        {
            Image = "IMG/explosion del misile.png";
        }

        public override void Update()
        {
            base.Update();
            Timer = Timer + Program.deltatime;
            if(Timer >= 0.25f)
            {


                Destroy();
            }
        }

        public override void Destroy()
        {
            base.Destroy();

            int rnd = Program.random.Next(0, 100);

            if (rnd < 50)
            {
                HealPickUp Hpu1 = new HealPickUp();
                Hpu1.X = X;
                Hpu1.Y = Y;
                Hpu1.ScaleX = 0.1f;
                Hpu1.ScaleY = 0.1f;
                Hpu1.OffsetX = 260 * Hpu1.ScaleX / 2;
                Hpu1.OffsetY = 260 * Hpu1.ScaleY / 2;
                Hpu1.Angle = Angle;
                Hpu1.Radius = 20;
                
            }

            if (rnd >= 50 && rnd < 100)
            {
                MissileAmmo Ma1 = new MissileAmmo();
                Ma1.X = X + 50;
                Ma1.Y = Y + 50;
                Ma1.ScaleX = 0.2f;
                Ma1.ScaleY = 0.2f;
                Ma1.OffsetX = 198 * Ma1.ScaleX / 2;
                Ma1.OffsetY = 93 * Ma1.ScaleY / 2;
                Ma1.Angle = Angle;
                Ma1.Radius = 20;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Character : Collision
    {
        float life;
        public Manager Manager { get; set; }
        public float ShootingTime { get; set; }
        public float MaximumLife { get; set; }
        float points;
        public float MaximumPoints { get; set; }
        public float Points
        {
            get { return points; }
            set
            {
                points = value; if (points > MaximumPoints) { points = MaximumPoints; }
                if (points <= 0) { points = 0; }
            }
        }

        public float Life
        {
            get { return life; }
            set
            {
                life = value; if (life > MaximumLife) { life = MaximumLife; }
                if (life <= 0) { life = 0; }
            }
        }

        public Character()
        {
            Program.Characters.Add(this);
        }

        public override void Destroy()
        {
            base.Destroy();
            Program.Characters.Remove(this);
        }

        public override void Update()
        {
            base.Update();
            Dead();
        }

        public void Dead()
        {
            if (Life <= 0)
            {
                Destroy();
                Explosion Exp1 = new Explosion();
                Exp1.X = X;
                Exp1.Y = Y;
                Exp1.ScaleX = 1;
                Exp1.ScaleY = 1;
                Exp1.OffsetX = 240 * Exp1.ScaleX / 2;
                Exp1.OffsetY = 240 * Exp1.ScaleY/ 2;
                Exp1.Angle = Angle;
                Manager.Points += points;
                
            }
        }
    }
}

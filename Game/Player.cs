using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Player : Character
    {
        int maximunMissileAmmunition;
        int missileAmmunition;
        public int MissileAmmunition
        {
            get { return missileAmmunition; }
            set
            {
                missileAmmunition = value;
                if (missileAmmunition > maximunMissileAmmunition) { missileAmmunition = maximunMissileAmmunition; }
                if (missileAmmunition <= 0) { missileAmmunition = 0; }
            }
        }

        public Player()
        {
            MaximumLife = 500;
            Image = "IMG/Nave del capitan Kirk.png";
            ScaleX = 0.1f;
            ScaleY = 0.1f;
            Angle = 270;
            OffsetX = 51.05f;
            OffsetY = 37.4f;
            Speed = 250;
            MaximumLife = 200;
            Life = MaximumLife;
            maximunMissileAmmunition = 3;
            missileAmmunition = maximunMissileAmmunition;
            Radius = 51.05f;
            Timer = 0;
            ShootingTime = 0.85f;
            Group = "Player";
            Width = 1021 * ScaleX / 2;
            Height = 748 * ScaleY / 2;
            Points = 50;
        }

        public override void Update()
        {
            base.Update();
            Movement();
            Rotation();
            ShootLaser();
            ShootMissile();

        }

        public void Movement()
        {
            if (Engine.GetKey(Keys.W) && Y >= 0 + 51.05f)
                Y -= Speed * Program.deltatime;

            if (Engine.GetKey(Keys.S) && Y <= 600 - 51.05f)
                Y += Speed * Program.deltatime;

            if (Engine.GetKey(Keys.D) && X <= 800 - 37.4f)
                X += Speed * Program.deltatime;

            if (Engine.GetKey(Keys.A) && X >= 0 + 37.4f)
                X -= Speed * Program.deltatime;
        }

        public void Rotation()
        {
            if (Engine.GetKey(Keys.RIGHT))
                Angle += Speed * Program.deltatime;

            if (Engine.GetKey(Keys.LEFT))
                Angle -= Speed * Program.deltatime;
        }

        public void ShootLaser()
        {
            Timer = Timer + Program.deltatime;
            if (Engine.GetKey(Keys.V) && Timer >= ShootingTime)
            {
                Laser L1 = new Laser();
                L1.X = X;
                L1.Y = Y;
                L1.Angle = Angle;
                L1.ScaleX = 0.05f;
                L1.ScaleY = 0.05f;
                L1.Width = 890 * L1.ScaleX;
                L1.Height = 500 * L1.ScaleY;
                L1.OffsetX = L1.Width / 2;
                L1.OffsetY = L1.Height / 2;
                L1.Group = Group;
                Timer = 0;
                
            }
        }

        public void ShootMissile()
        {
            Timer = Timer + Program.deltatime;
            if (Engine.GetKey(Keys.B) && Timer >= ShootingTime + 0.85f && missileAmmunition >= 1)
            {
                Missile M1 = new Missile();
                M1.X = X;
                M1.Y = Y;
                M1.Angle = Angle;
                M1.ScaleX = 0.1f;
                M1.ScaleY = 0.1f;
                M1.Width = 321 * M1.ScaleX;
                M1.Height = 328 * M1.ScaleY;
                M1.OffsetX = M1.Width / 2;
                M1.OffsetY = M1.Height / 2;
                M1.Group = Group;
                missileAmmunition -= 1;
                Timer = 0;
                
            }
        }
    }
}

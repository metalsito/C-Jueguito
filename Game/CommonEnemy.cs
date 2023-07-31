using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class CommonEnemy : Character
    {
        public enum Status { MoveRight, Shootgun, MoveLeft, Shootgun2 }

        public Player Player { get; set; }
        public Status Condition { get; private set; }        

        public CommonEnemy()
        {
            Image = "IMG/Enemigo comun.png";
            MaximumLife = 100;
            MaximumPoints = 50;
            X = 200;
            Y = 200;
            ScaleX = 0.3f;
            ScaleY = 0.3f;
            Angle = 90;
            OffsetX = 48f;
            OffsetY = 48f;
            Speed = 120;
            MaximumLife = 100;
            Life = MaximumLife;
            Radius = 48f;
            Timer = 0;
            ShootingTime = 1.4f;
            Group = "Enemy";
            Points = MaximumPoints;
            Timer2 = 0;
            Timer3 = 0;
            Height = 320 * ScaleX / 2;
            Width = 320 * ScaleY / 2;

        }

        public override void Update()
        {
            base.Update();
            if(Condition == Status.MoveRight)
            {
                MoveRight();
            }
            else if (Condition == Status.Shootgun)
            {
                Shootgun();
            }
            else if(Condition == Status.MoveLeft)
            {
                MoveLeft();
            }
            else if(Condition == Status.Shootgun2)
            {
                Shootgun2();
            }

            LookToPlayer();
            
        }

        public void MoveRight()
        {
            X += Speed * Program.deltatime;
            ShootLaser();
            if(X >= 700)
            {
                Condition = Status.Shootgun;
            }
        }

        public void Shootgun()
        {
            Timer2 = Timer2 + Program.deltatime;
            ShootgunLaser();
            if (Timer2 >= 2)
            {
                Condition = Status.MoveLeft;
                Timer = 0;
            }
        }

        public void MoveLeft()
        {
            X -= Speed * Program.deltatime;
            ShootLaser();
            if(X <= 100)
            {
                Condition = Status.Shootgun2;
            }
        }

        public void Shootgun2()
        {
            Timer2 = Timer2 + Program.deltatime;
            ShootgunLaser();
            if(Timer2 >= 2)
            {
                Condition = Status.MoveRight;
                Timer = 0;
            }
        }

        public void ShootLaser()
        {
            Timer = Timer + Program.deltatime;
            if (Timer >= ShootingTime)
            {
                Laser L2 = new Laser();
                L2.X = X;
                L2.Y = Y;
                L2.Angle = Angle;
                L2.ScaleX = 0.05f;
                L2.ScaleY = 0.05f;
                L2.Width = 890 * L2.ScaleX;
                L2.Height = 500 * L2.ScaleY;
                L2.OffsetX = L2.Width / 2;
                L2.OffsetY = L2.Height / 2;
                L2.Group = Group;
                Timer = 0;

            }
        }

        public void ShootgunLaser()
        {
            Timer = Timer + Program.deltatime;
            if (Timer >= ShootingTime)
            {
                Laser L3 = new Laser();
                L3.X = X;
                L3.Y = Y;
                L3.Angle = Angle;
                L3.ScaleX = 0.05f;
                L3.ScaleY = 0.05f;
                L3.Width = 890 * L3.ScaleX;
                L3.Height = 500 * L3.ScaleY;
                L3.OffsetX = L3.Width / 2;
                L3.OffsetY = L3.Height / 2;
                L3.Group = Group;


                Laser L4 = new Laser();
                L4.X = X - 30;
                L4.Y = Y;
                L4.Angle = Angle + 45;
                L4.ScaleX = 0.05f;
                L4.ScaleY = 0.05f;
                L4.Width = 890 * L4.ScaleX;
                L4.Height = 500 * L4.ScaleY;
                L4.OffsetX = L4.Width / 2;
                L4.OffsetY = L4.Height / 2;
                L4.Group = Group;


                Laser L5 = new Laser();
                L5.X = X + 30;
                L5.Y = Y;
                L5.Angle = Angle - 45;
                L5.ScaleX = 0.05f;
                L5.ScaleY = 0.05f;
                L5.Width = 890 * L5.ScaleX;
                L5.Height = 500 * L5.ScaleY;
                L5.OffsetX = L5.Width / 2;
                L5.OffsetY = L5.Height / 2;
                L5.Group = Group;

                Timer = 0;
            }
        }

        public void LookToPlayer()
        {
            float DiffXPlayer = Player.X - X;
            float DiffYPlayer = Player.Y - Y;
            float DistPlayer = (float)Math.Sqrt(DiffXPlayer * DiffXPlayer + DiffYPlayer * DiffYPlayer);
            Angle = (float)Math.Atan2(DiffYPlayer, DiffXPlayer) * Program.radiansToDegrees;
        }
    }
}

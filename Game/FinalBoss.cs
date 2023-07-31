using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class FinalBoss : Character
    {
        //TODO: Hacer que el manager me pase la referencia
        //TODO: Evitar tener variables publicas
        
        public enum Status { MoveRight, Shootgun, MoveLeft, Shootgun2 }

        Status condition;
        public Player Player { get; set; }

        public FinalBoss()
        {
            Image = "IMG/Nave del comandante Mallhu Zelkas.png";
            MaximumLife = 400;
            X = 200;
            Y = 200;
            ScaleX = 0.15f;
            ScaleY = 0.15f;
            Angle = 90;
            OffsetX = 120f;
            OffsetY = 120f;
            Speed = 30;
            MaximumLife = 300;
            Life = MaximumLife;
            Radius = 120f;
            Timer = 0;
            ShootingTime = 1.55f;
            Group = "Enemy";
            Points = 100;
            Width = 240;
            Height = 240;
        }

        public override void Update()
        {
            base.Update();
            if (condition == Status.MoveRight)
            {
                MoveRight();
            }
            else if (condition == Status.Shootgun)
            {
                Shootgun();
            }
            else if (condition == Status.MoveLeft)
            {
                MoveLeft();
            }
            else if (condition == Status.Shootgun2)
            {
                Shootgun2();
            }

            LookToPlayer();
        }

        public void MoveRight()
        {
            X += Speed * Program.deltatime;
            Y += Speed * Program.deltatime;
            ShootLaser();
            if (X >= 700 && Y >= 500)
            {
                condition = Status.Shootgun;
            }
        }

        public void Shootgun()
        {
            Timer2 = Timer2 + Program.deltatime;
            ShootgunLaser();
            if (Timer2 >= 4)
            {
                condition = Status.MoveLeft;
                Timer2 = 0;
            }
        }

        public void MoveLeft()
        {
            X -= Speed * Program.deltatime;
            Y -= Speed * Program.deltatime;
            ShootLaser();
            if (X <= 300 && Y <= 300)
            {
                condition = Status.Shootgun2;
            }
        }

        public void Shootgun2()
        {
            Timer2 = Timer2 + Program.deltatime;
            ShootgunLaser();
            if (Timer2 >= 4)
            {
                condition = Status.MoveRight;
                Timer2 = 0;
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
                L2.ScaleX = 0.1f;
                L2.ScaleY = 0.1f;
                L2.Width = 890 * L2.ScaleX;
                L2.Height = 500 * L2.ScaleY;
                L2.OffsetX = L2.Width / 2;
                L2.OffsetY = L2.Height / 2;
                L2.Group = Group;
                Timer = 0;

                Laser L6 = new Laser();
                L6.X = X + 30;
                L6.Y = Y;
                L6.Angle = Angle;
                L6.ScaleX = 0.1f;
                L6.ScaleY = 0.1f;
                L6.Width = 890 * L6.ScaleX;
                L6.Height = 500 * L6.ScaleY;
                L6.OffsetX = L6.Width / 2;
                L6.OffsetY = L6.Height / 2;
                L6.Group = Group;
                Timer = 0;

                Laser L7 = new Laser();
                L7.X = X - 30;
                L7.Y = Y;
                L7.Angle = Angle;
                L7.ScaleX = 0.1f;
                L7.ScaleY = 0.1f;
                L7.Width = 890 * L7.ScaleX;
                L7.Height = 500 * L7.ScaleY;
                L7.OffsetX = L7.Width / 2;
                L7.OffsetY = L7.Height / 2;
                L7.Group = Group;
                Timer = 0;

                Laser L8 = new Laser();
                L8.X = X + 65;
                L8.Y = Y + 65;
                L8.Angle = Angle;
                L8.ScaleX = 0.1f;
                L8.ScaleY = 0.1f;
                L8.Width = 890 * L8.ScaleX;
                L8.Height = 500 * L8.ScaleY;
                L8.OffsetX = L8.Width / 2;
                L8.OffsetY = L8.Height / 2;
                L8.Group = Group;
                Timer = 0;

                Laser L9 = new Laser();
                L9.X = X - 65;
                L9.Y = Y + 65;
                L9.Angle = Angle;
                L9.ScaleX = 0.1f;
                L9.ScaleY = 0.1f;
                L9.Width = 890 * L9.ScaleX;
                L9.Height = 500 * L9.ScaleY;
                L9.OffsetX = L9.Width / 2;
                L9.OffsetY = L9.Height / 2;
                L9.Group = Group;
                Timer = 0;

            }
        }

        public void ShootgunLaser()
        {
            Timer = Timer + Program.deltatime;
            if (Timer >= ShootingTime - 0.55f)
            {
                Timer = 0;
                Laser L3 = new Laser();
                L3.X = X;
                L3.Y = Y;
                L3.Angle = Angle;
                L3.ScaleX = 0.2f;
                L3.ScaleY = 0.2f;
                L3.Width = 890 * L3.ScaleX;
                L3.Height = 500 * L3.ScaleY;
                L3.OffsetX = L3.Width / 2;
                L3.OffsetY = L3.Height / 2;
                L3.Group = Group;


                Laser L4 = new Laser();
                L4.X = X - 30;
                L4.Y = Y;
                L4.Angle = Angle + 25;
                L4.ScaleX = 0.2f;
                L4.ScaleY = 0.2f;
                L4.Width = 890 * L4.ScaleX;
                L4.Height = 500 * L4.ScaleY;
                L4.OffsetX = L4.Width / 2;
                L4.OffsetY = L4.Height / 2;
                L4.Group = Group;


                Laser L5 = new Laser();
                L5.X = X + 30;
                L5.Y = Y;
                L5.Angle = Angle - 25;
                L5.ScaleX = 0.2f;
                L5.ScaleY = 0.2f;
                L5.Width = 890 * L5.ScaleX;
                L5.Height = 500 * L5.ScaleY;
                L5.OffsetX = L5.Width / 2;
                L5.OffsetY = L5.Height / 2;
                L5.Group = Group;

                
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

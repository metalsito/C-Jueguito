using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Projectile : Collision
    {
        public float Damage { get; set; }
        

        public Projectile()
        {
            Program.Pojectiles.Add(this);
        }

        public override void Update()
        {
            base.Update();
            Movement();
        }

        protected override bool CollisionCheck(Collision other)
        {
            float DiffX = Math.Abs(X - other.X);
            float DiffY = Math.Abs(Y - other.Y);
            float SumHalfWidth = Width / 2 + other.Width / 2;
            float SumHalfHigh = Height / 2 + other.Height / 2;
            return DiffX <= SumHalfWidth && DiffY <= SumHalfHigh;
        }

        public void Movement()
        {
            float rad = Angle * Program.degreesToRadians;
            X += (float)Math.Cos(rad) * Speed * Program.deltatime;
            Y += (float)Math.Sin(rad) * Speed * Program.deltatime;

            if (X >= 800 || X <= 0 || Y >= 600 || Y <= 0)
            {
                Destroy();
            }
        }

        public override void Destroy()
        {
            base.Destroy();
            Program.Pojectiles.Remove(this);
        }

        public override void OnCollision(Collision other)
        {
            
            Character character = other as Character;
            if (character != null)
            {
                character.Life -= Damage;
                Destroy();
            }

            
        }
    }
}

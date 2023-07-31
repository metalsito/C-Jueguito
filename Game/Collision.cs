using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Collision : Drawable
    {
        public float Timer { get; set; }
        public float Timer2 { get; set; }
        public float Timer3 { get; set; }
        public float Radius { get; set; }
        public string Group { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Speed { get; set; }
        

        public Collision()
        {
            Program.Collisionable.Add(this);
        }

        public override void Update()
        {
            base.Update();
            Collisions();
        }

        private void Collisions()
        {
            for (int i = 0; i < Program.Collisionable.Count; i++)
            {
                Collision col = Program.Collisionable[i];

                if (col != this && (Group == null || col.Group == null || Group != col.Group))
                {
                    if (CollisionCheck(col))
                    {
                        OnCollision(col);
                    }
                }
            }
        }

        protected virtual bool CollisionCheck(Collision other)
        {
            float DiffX = X - other.X;
            float DiffY = Y - other.Y;
            float Dist = (float)Math.Sqrt(DiffX * DiffX + DiffY * DiffY);
            return Dist < Radius + other.Radius;
        }

        public override void Destroy()
        {
            base.Destroy();
            Program.Collisionable.Remove(this);
        }

        public virtual void OnCollision(Collision other)
        {

        }
    }
}

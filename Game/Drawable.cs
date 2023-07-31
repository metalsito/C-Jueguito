using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Drawable : Entity
    {
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        public float OffsetX { get; set; }
        public float OffsetY { get; set; }
        public string Image { get; set; }

        public Drawable()
        {
            Program.Drawings.Add(this);
        }

        public virtual void Draw()
        {
            Engine.Draw(Image, X, Y, ScaleX, ScaleY, Angle, OffsetX, OffsetY);
        }

        public override void Destroy()
        {
            base.Destroy();
            Program.Drawings.Remove(this);
        }
    }
}

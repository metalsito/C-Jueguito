using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Entity
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Angle { get; set; }

        //TODO: Mover esto a las clases correspondientes
        
        public Entity()
        {
            Program.Entities.Add(this);
        }

        public virtual void Update()
        {

        }

        public virtual void Destroy()
        {
            Program.Entities.Remove(this);
        }
    }
}

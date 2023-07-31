using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class PickUp : Collision
    {
       
        public PickUp()
        {
            Program.PickUps.Add(this);
        }

        public override void Destroy()
        {
            base.Destroy();
            Program.PickUps.Remove(this);
        }
    }
}

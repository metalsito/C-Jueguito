using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Laser : Projectile
    {
        public Laser()
        {
            Image = "IMG/laser.png";
            Speed = 600;
            Damage = 25;
        }
    }
}

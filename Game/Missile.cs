using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Missile : Projectile
    {
        public Missile()
        {
            Image = "IMG/misil.png";
            Speed = 450;
            Damage = 100;
        }
    }
}

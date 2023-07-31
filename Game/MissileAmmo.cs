using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class MissileAmmo : PickUp
    {
        public int Ammo { get; set; }

        public MissileAmmo()
        {
            Image = "IMG/caja de municion.png";
            Timer = 0;
            Ammo = 2;
            Group = "Enemy";
        }

        public override void Update()
        {
            base.Update();
            Timer = Timer + Program.deltatime;
            if (Timer >= 10)
            {
                Destroy();
            }
        }

        public override void Destroy()
        {
            base.Destroy();
            Program.PickUps.Remove(this);
        }

        public override void OnCollision(Collision other)
        {
            base.OnCollision(other);
            Player character = other as Player;
            if (character != null)
            {
                character.MissileAmmunition += Ammo;
                Destroy();
            }
        }
    }
}

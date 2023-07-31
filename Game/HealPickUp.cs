using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class HealPickUp : PickUp
    {
        public float Heal { get; set; }

        public HealPickUp()
        {
            Image = "IMG/heal.jpg";
            Timer = 0;
            Heal = 100;
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
            Character character = other as Character;
            if (character != null)
            {
                character.Life += Heal;
                Destroy();
            }
        }
    }
}

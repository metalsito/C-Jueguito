using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    
    public class Manager : Entity
    {
        bool AlreadySpawned;
        float points;
        public float MaximumPoints { get; set; }
        public float Points
        {
            get { return points; }
            set
            {
                points = value; if (points > MaximumPoints) { points = MaximumPoints; }
                if (points <= 0) { points = 0; }
            }
        }
        public Player Player { get; set; }

        public Manager()
        {
            MaximumPoints = 300;
            Points = 0;
        }

        public override void Update()
        {
            base.Update();
            if(Points >= 200 && !AlreadySpawned)
            {
                AlreadySpawned = true;
                FinalBoss FB1 = new FinalBoss();
                FB1.Player = Player;
                FB1.X = 380;
                FB1.Y = 200;
                FB1.Manager = this;
                

            }

        }
    }
}

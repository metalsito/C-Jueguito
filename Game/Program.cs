
using System;
using System.Collections.Generic;


namespace Game
{
    public class Program
    {
        public static float tiempoActual;
        public static float deltatime;
        public static float degreesToRadians = 0.01745329251f;
        public static float radiansToDegrees = 57.2957795131f;
        public static Random random = new Random();
        public static List<Entity> Entities = new List<Entity>();
        public static List<Drawable> Drawings = new List<Drawable>();
        public static List<Collision> Collisionable = new List<Collision>();
        public static List<Projectile> Pojectiles = new List<Projectile>();
        public static List<Character> Characters = new List<Character>();
        public static List<PickUp> PickUps = new List<PickUp>();

        static void Main(string[] args)
        {
            Engine.Initialize("SpaceConflict", 800, 600);
            DateTime fechaInicio = DateTime.Now;
            float tiempoFrameAnterior = 0;

            Manager M1 = new Manager();

            Player P1 = new Player();
            P1.X = 380;
            P1.Y = 500;
            P1.Manager = M1;
            M1.Player = P1;

            CommonEnemy CE1 = new CommonEnemy();
           CE1.Player = P1;
           CE1.Manager = M1;
           CE1.X = 200;
           CE1.Y = 250;

           CommonEnemy CE2 = new CommonEnemy();
           CE2.Player = P1;
           CE2.Manager = M1;
           CE2.X = 265;
           CE2.Y = 315;

           /* CommonEnemy CE3 = new CommonEnemy();
           CE3.Player = P1;
           CE3.Manager = M1;
           CE3.X = 365;
           CE3.Y = 250;

            CommonEnemy CE4 = new CommonEnemy();
            CE4.Player = P1;
            CE4.X = 400;
            CE4.Y = 315;
            CE4.Manager = M1; */

            HeavyEnemy HE1 = new HeavyEnemy();
            HE1.Player = P1;
            HE1.X = 380;
            HE1.Y = 150;
            HE1.Manager = M1;

            while (true)
            {
                TimeSpan tiempoDesdeInicio = DateTime.Now - fechaInicio;
                Program.tiempoActual = (float)tiempoDesdeInicio.TotalSeconds;
                Program.deltatime = Program.tiempoActual - tiempoFrameAnterior;
                tiempoFrameAnterior = Program.tiempoActual;

                

                for (int i = 0; i < Program.Entities.Count; i++)
                {
                    Program.Entities[i].Update();
                }

                Engine.Clear();

                Engine.Draw("IMG/fondo de pantalla.jpg");

                for (int i = 0; i < Program.Drawings.Count; i++)
                {
                    Program.Drawings[i].Draw();
                }

                Engine.Show();

                
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;
using System.Diagnostics;

namespace Test
{
    class Powerups
    {
        Speed[] speed;
        Unsterblich[] invis;
        public Powerups()
        {
            speed = new Speed[3]; //Anzahl der Speed Objekte
            invis = new Unsterblich[3];
                speed[0] = new Speed(new Vector2f(600, 800)); //Speed wird erstellt und Position gesetzt.
                speed[1] = new Speed(new Vector2f(1000, 700));
                speed[2] = new Speed(new Vector2f(1200, 600));
            invis[0] = new Unsterblich(new Vector2f(800, 900));
            invis[1] = new Unsterblich(new Vector2f(1800, 900));
            invis[2] = new Unsterblich(new Vector2f(2800, 800));


        }

        public void Update(GameTime gTime)
        {
            foreach(Speed t in speed)
            {
                if(t.a || t.special.Ticks != 0) //Entweder wenn Objekt speed aktiviert oder wenn der TImer noch aktiv ist
                    t.Update(gTime);
            }
            foreach(Unsterblich q in invis)
            {
                if (q.a || q.special.Ticks != 0)
                    q.Update(gTime);
            }
        }

        public void Draw(RenderWindow window)
        {
            foreach(Speed t in speed)
            {
                if (t.a) //Wenn nicht mehr aktiv -> Wird nicht mehr gezeichnet.
                    t.Draw(window);
            }
            foreach (Unsterblich t in invis)
            {
                if (t.a) //Wenn nicht mehr aktiv -> Wird nicht mehr gezeichnet.
                    t.Draw(window);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "The Bug Bang Theory");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };
                RectangleShape rechteck = new RectangleShape(new Vector2f(320, 320));
                rechteck.Position = new Vector2f(50, 12);
                rechteck.FillColor = new Color(0, 0, 255);

            CircleShape kreis = new CircleShape(50,8);
            kreis.Position = new Vector2f(200, 200);
            kreis.Origin = new Vector2f(kreis.Radius,kreis.Radius);
            kreis.FillColor = new Color(255, 0, 0);
            float a, c;
            a = c = 250f;
                
            while (window.IsOpen())
            {
                window.Clear(new Color(0,128,0,0));
                kreis.Position = new Vector2f(a, c);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && kreis.Position.X > kreis.Radius)
                {
                    a -= 0.1f;
                    kreis.Rotation -= 0.1f;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && kreis.Position.X < window.Size.X - kreis.Radius)
                {
                    a += 0.1f;
                    kreis.Rotation += 0.1f;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down) && kreis.Position.Y < window.Size.Y - kreis.Radius)
                {
                    c += 0.1f;
                    kreis.Rotation += 0.1f;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && kreis.Position.Y > kreis.Radius)
                {
                    c -= 0.1f;
                    kreis.Rotation -= 0.1f;
                }


                window.Draw(rechteck);
                window.Draw(kreis);
               
                window.Display();
                window.DispatchEvents();

            }
        }
    }
}

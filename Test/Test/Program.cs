using System;
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
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "LoL");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };


            CircleShape rechteck = new CircleShape(50,3);
            rechteck.Position = new Vector2f(50, 12);
            rechteck.Origin = new Vector2f(rechteck.Radius, rechteck.Radius);
            rechteck.FillColor = new Color(0, 0, 255);

            CircleShape kreis = new CircleShape(50,6);
            kreis.Position = new Vector2f(200, 200);
            kreis.Origin = new Vector2f(kreis.Radius,kreis.Radius);
            kreis.FillColor = new Color(255, 0, 0);
            float a, b,c,d;
            a = b = 250f;
            c = d = 150f;
            Vector2f linie = new Vector2f(kreis.Position.X - rechteck.Position.X, kreis.Position.Y - rechteck.Position.Y);
            double liniex, liniey;
            liniex = System.Convert.ToDouble(linie.X);
            liniey = System.Convert.ToDouble(linie.Y);
            float abstand = System.Convert.ToSingle(Math.Sqrt(Math.Pow(liniex, 2) + Math.Pow(liniey, 2)));
                
            while (window.IsOpen())
            {
                window.Clear(new Color(0,0,0,0));

                linie = new Vector2f(kreis.Position.X - rechteck.Position.X, kreis.Position.Y - rechteck.Position.Y);
                liniex = System.Convert.ToDouble(linie.X);
                liniey = System.Convert.ToDouble(linie.Y);
                abstand = System.Convert.ToSingle(Math.Sqrt(Math.Pow(liniex, 2) + Math.Pow(liniey, 2)));

                kreis.Position = new Vector2f(a, b);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && kreis.Position.X > kreis.Radius)
                {
                    if(abstand>100 || kreis.Position.X <= rechteck.Position.X)
                    {
                        a -= 0.1f;
                        kreis.Rotation -= 0.1f;
                    }
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && kreis.Position.X < window.Size.X - kreis.Radius)
                {
                    if(abstand>100 || kreis.Position.X >= rechteck.Position.X)
                    {
                        a += 0.1f;
                        kreis.Rotation += 0.1f;
                    }
                    
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down) && kreis.Position.Y < window.Size.Y - kreis.Radius)
                {
                    if(abstand>100 || kreis.Position.Y >= rechteck.Position.Y)
                    {
                        b += 0.1f;
                        kreis.Rotation += 0.1f;
                    }
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && kreis.Position.Y > kreis.Radius)
                {
                    if(abstand>100 || kreis.Position.Y <= rechteck.Position.Y)
                    {
                        b -= 0.1f;
                        kreis.Rotation -= 0.1f;
                    }
                }

                linie = new Vector2f(kreis.Position.X - rechteck.Position.X, kreis.Position.Y - rechteck.Position.Y);
                liniex = System.Convert.ToDouble(linie.X);
                liniey = System.Convert.ToDouble(linie.Y);
                abstand = System.Convert.ToSingle(Math.Sqrt(Math.Pow(liniex, 2) + Math.Pow(liniey, 2)));

                rechteck.Position = new Vector2f(c, d);
                if (Keyboard.IsKeyPressed(Keyboard.Key.A) && rechteck.Position.X > rechteck.Radius)
                {
                    if(abstand>100 || rechteck.Position.X <= kreis.Position.X)
                    {
                        c -= 0.1f;
                        rechteck.Rotation -= 0.1f;
                    }
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.D) && rechteck.Position.X < window.Size.X - rechteck.Radius)
                {
                    if(abstand>100 || rechteck.Position.X >= kreis.Position.X)
                    {
                        c += 0.1f;
                        rechteck.Rotation += 0.1f;
                    }
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.S) && rechteck.Position.Y < window.Size.Y - rechteck.Radius)
                {
                    if(abstand>100 || rechteck.Position.Y >= kreis.Position.Y)
                    {
                        d += 0.1f;
                        rechteck.Rotation += 0.1f;
                    }
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.W) && rechteck.Position.Y > rechteck.Radius)
                {
                    if(abstand>100 || rechteck.Position.Y <= kreis.Position.Y)
                    {
                        d -= 0.1f;
                        rechteck.Rotation -= 0.1f;
                    }
                    
                }


                window.Draw(rechteck);
                window.Draw(kreis);
               
                window.Display();
                window.DispatchEvents();

            }
        }
    }
}

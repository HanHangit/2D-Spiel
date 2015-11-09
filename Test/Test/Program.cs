using System;
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
    class Program
    {
        static void Main(string[] args)
        {
            
            int anzahlgeist = 15;
            Enemy[] geist = new Enemy[anzahlgeist];
            for(int i = 0; i < anzahlgeist; ++i)
            geist[i] = new Enemy("Geist");

            //Enemy hinher = new Enemy("Geist");
            //hinher.setposition(new Vector2f(500,500));

           
            Player player  = new Player("Cookie");

            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "LoL");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };


            //Timer
            Stopwatch timer = new Stopwatch();
            Stopwatch frametimegeist = new Stopwatch();
            Stopwatch frametimeplayer = new Stopwatch();
            TimeSpan time = new TimeSpan();
            timer.Start();
            frametimegeist.Start();
            frametimeplayer.Start();
            window.SetFramerateLimit(200);


            while (window.IsOpen())
            {
                window.Clear(Color.Cyan);
                for (int i = 0; i < anzahlgeist; ++i)
                {
                    geist[i].draw(window);
                }
                geist[0].verfolgen(geist[0].position(), player.position(),0.2f * time.Milliseconds);
                for (int i = 1; i < anzahlgeist; ++i)
                {
                    geist[i].verfolgen(geist[i].position(), geist[i - 1].position(), 0.2f * time.Milliseconds);
                }
                player.Draw(window);
                player.move(window.Size, 0.3f * time.Milliseconds);
                //hinher.pendeln(new Vector2f(500, 500), new Vector2f(700, 500), 2f);
                //hinher.draw(window);
                window.Display();
                window.DispatchEvents();

                if (frametimegeist.Elapsed.Milliseconds >= 500)
                {
                    for (int i = 0; i < anzahlgeist; ++i)
                    {
                        geist[i].animation();
                    }
                    frametimegeist.Restart();
                }

                if (frametimeplayer.Elapsed.Milliseconds >= 100) 
                {
                    player.animation();
                    frametimeplayer.Restart();
                }

                
                time = timer.Elapsed;
                timer.Restart();

                
            }
        }
    }
}

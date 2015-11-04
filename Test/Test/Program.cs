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
            
            int anzahlgeist = 10;
            Enemy[] geist = new Enemy[anzahlgeist];
            for(int i = 0; i < anzahlgeist; ++i)
            geist[i] = new Enemy("Geist");

            //Enemy hinher = new Enemy("Geist");
            //hinher.setposition(new Vector2f(500,500));

           
            Player player  = new Player();

                
            Enemy tofu = new Enemy("Tofu");
            tofu.setposition(new Vector2f(500, 500));

            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "LoL");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };

            Stopwatch timer = new Stopwatch();
            TimeSpan geisttime = new TimeSpan();
            TimeSpan playertime = new TimeSpan(); 
            TimeSpan time = new TimeSpan();
            time = new TimeSpan(10000);
            window.SetFramerateLimit(120);

            //public static Map map { get; private set; };


            timer.Start();


            while (window.IsOpen())
            {
                window.Clear(Color.Cyan);

                
                for (int i = 0; i < anzahlgeist; ++i)
                {
                    geist[i].draw(window);
                }
                geist[0].verfolgen(geist[0].position(), player.position(),0.1f * time.Milliseconds);
                for (int i = 1; i < anzahlgeist; ++i)
                {
                    geist[i].verfolgen(geist[i].position(), geist[i - 1].position(), 0.1f * time.Milliseconds);
                }
                tofu.draw(window);
                tofu.verfolgen(tofu.position(), geist[anzahlgeist - 1].position(),0.1f * time.Milliseconds);
                player.Draw(window);
                player.move(window.Size, 0.2f * time.Milliseconds);
                //hinher.pendeln(new Vector2f(500, 500), new Vector2f(700, 500), 2f);
                //hinher.draw(window);
                window.Display();
                window.DispatchEvents();

                geisttime += time;
                if (geisttime.Milliseconds > 400)
                {
                    for (int i = 0; i < anzahlgeist; ++i)
                    {
                        geist[i].animation();
                    }
                    geisttime = new TimeSpan(0);
                }

                playertime += time;
                if (playertime.Milliseconds > 100)
                {
                    player.animation();
                    playertime = new TimeSpan(0);
                }



                    time = timer.Elapsed;                    
                    timer.Restart();

                
            }
        }
    }
}

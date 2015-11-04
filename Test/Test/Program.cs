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
            Stopwatch frametimegeist = new Stopwatch();
            Stopwatch frametimeplayer = new Stopwatch();
            TimeSpan time = new TimeSpan();
            int dt = 0;


            timer.Start();
            frametimegeist.Start();
            frametimeplayer.Start();


            while (window.IsOpen())
            {

                
<<<<<<< HEAD
                window.Clear(Color.Cyan);
=======

                
                window.Clear(Color.Magenta);
>>>>>>> 08bc8b1def049c66add7cc28ce9d4a129ec0abc2
                for (int i = 0; i < anzahlgeist; ++i)
                {
                    geist[i].draw(window);
                }
                geist[0].verfolgen(geist[0].position(), player.position(),2f);
                for (int i = 1; i < anzahlgeist; ++i)
                {
                    geist[i].verfolgen(geist[i].position(), geist[i - 1].position(), 2f);
                }
                tofu.draw(window);
                tofu.verfolgen(tofu.position(), geist[anzahlgeist - 1].position(),2f);
                player.Draw(window);
                player.move(window.Size);
                //hinher.pendeln(new Vector2f(500, 500), new Vector2f(700, 500), 2f);
                //hinher.draw(window);
                window.Display();
                window.DispatchEvents();
                dt += 1;

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


                if (dt >= 60)
                {
                    time = timer.Elapsed;
                    Console.WriteLine(time.Milliseconds);
                    
                    timer.Restart();
                    dt = 0;
                }

                
            }
        }
    }
}

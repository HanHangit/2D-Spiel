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
        public static Player player { get; private set; }
        //Timer
        //public static Map map { get; private set; }



        public static void initialize()
        {
            int anzahlgeist = 15;
            Enemy[] geist = new Enemy[anzahlgeist];
            for (int i = 0; i < anzahlgeist; ++i)
                geist[i] = new Enemy("Geist");

            
            player = new Player("Cookie", new Vector2f(300, 300));
        }

        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(1200, 800), "LoL");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };
            
            initialize();
            Stopwatch timer = new Stopwatch();
            TimeSpan time = new TimeSpan();

            timer.Start();
            time = new TimeSpan(0, 0, 1);
            while (window.IsOpen())
            {
                window.Clear(Color.Cyan);
                Update(time);
                Draw(window);
                window.DispatchEvents();
                time = new TimeSpan(timer.ElapsedTicks);
                timer.Restart();

            }


        }
        static void Draw(RenderWindow window)
        {
            window.Clear(new Color(50, 120, 190));

            //map.Draw(window);
            player.Draw(window);
            

            window.Display();
        }
        static void Update(TimeSpan time)
        {
            player.Update();
            player.animation(time);
            
        }
    }
}

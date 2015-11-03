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
            
            int anzahlgeist = 10;
            Enemy[] geist = new Enemy[anzahlgeist];
            for(int i = 0; i < anzahlgeist; ++i)
            geist[i] = new Enemy("Geist");

           
            Player player  = new Player();

                
            Enemy tofu = new Enemy("Tofu");
            tofu.setposition(new Vector2f(500, 500));

            RenderWindow window = new RenderWindow(new VideoMode(1200, 800), "LoL");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };
                
            while (window.IsOpen())
            {

                
                window.Clear(new Color(0,0,0,0));
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
                window.Display();
                window.DispatchEvents();
               

            }
        }
    }
}

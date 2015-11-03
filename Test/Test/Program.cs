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
            
            int anzahlgeist = 5;
            Enemy[] geist = new Enemy[5];
            for(int i = 0; i < anzahlgeist; ++i)
            geist[i] = new Enemy("Geist");

           
            Player player  = new Player();

                
            Enemy tofu = new Enemy("Tofu");
            tofu.setposition(new Vector2f(500, 500));
            geist[2].setposition(new Vector2f(300, 300));
            geist[3].setposition(new Vector2f(400, 400));

            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "LoL");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };
                
            while (window.IsOpen())
            {

                
                window.Clear(new Color(0,0,0,0));
                for (int i = 0; i < anzahlgeist; ++i)
                    geist[i].draw(window);
                geist[1].verfolgen(geist[1].position(), player.position(),13f);
                geist[2].verfolgen(geist[2].position(), geist[1].position(), 14f);
                geist[3].verfolgen(geist[3].position(), geist[2].position(), 15f);
                tofu.draw(window);
                tofu.verfolgen(tofu.position(), geist[3].position(),20f);
                player.Draw(window);
                player.move(window.Size);
                window.Display();
                window.DispatchEvents();
               

            }
        }
    }
}

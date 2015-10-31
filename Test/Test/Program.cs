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
            Player player  = new Player();
            Enemy geist = new Enemy("Geist");
            Enemy tofu = new Enemy("Tofu");

            tofu.setposition(new Vector2f(500, 500));
            geist.setposition(new Vector2f(200, 200));

            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "LoL");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };
                
            while (window.IsOpen())
            {
                window.Clear(new Color(0,0,0,0));
                geist.draw(window);
                geist.verfolgen(geist.position(), player.position());
                tofu.draw(window);
                tofu.verfolgen(tofu.position(), player.position());
                player.Draw(window);
                player.move(window.Size);
                window.Display();
                window.DispatchEvents();
               

            }
        }
    }
}

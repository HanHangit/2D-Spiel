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
            Enemy geist1 = new Enemy("Geist");
            Enemy tofu = new Enemy("Tofu");
            Enemy geist2 = new Enemy("Geist");
            Enemy geist3 = new Enemy("Geist");
            tofu.setposition(new Vector2f(500, 500));

            geist1.setposition(new Vector2f(200, 200));
            geist2.setposition(new Vector2f(300, 300));
            geist3.setposition(new Vector2f(400, 400));

            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "LoL");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };
                
            while (window.IsOpen())
            {

                
                window.Clear(new Color(0,0,0,0));
                geist1.draw(window);
                geist1.verfolgen(geist1.position(), player.position(),10f);
                geist2.draw(window);
                geist3.draw(window);
                tofu.draw(window);
                tofu.verfolgen(tofu.position(), player.position(),15f);
                player.Draw(window);
                player.move(window.Size);
                window.Display();
                window.DispatchEvents();
               

            }
        }
    }
}

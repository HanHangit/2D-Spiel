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
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "The Bug Bang Theory");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };
            while (window.IsOpen())
            {
                window.Clear(new Color(0,128,0,0));
                window.Display();
                window.DispatchEvents();
                RectangleShape rechteck = new RectangleShape(new Vector2f(320, 320));
                window.Draw(rechteck);
                rechteck.Position = new Vector2f(12, 12);
                rechteck.FillColor = new Color(0, 0, 255);
                              
            }
        }
    }
}

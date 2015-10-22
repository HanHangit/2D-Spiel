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
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Test01");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };
            while (window.IsOpen())
            {
                window.Clear();
                window.Display();
                window.DispatchEvents();
            }
        }
    }
}

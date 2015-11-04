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
    class Tile
    {
        RectangleShape shape;
        public bool Walkable { get; private set; }

        public Tile(Color color, Vector2f position, bool walkable, Vector2f size)
        {
            shape = new RectangleShape(size);
            shape.FillColor = color;
            shape.Position = position;
            Walkable = walkable;
        }


        public void draw(RenderWindow window)
        {
            window.Draw(shape);
        }
    }
}

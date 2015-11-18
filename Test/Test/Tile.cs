using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Test
{
    class Tile
    {
        RectangleShape shape;
        
        public bool Walkable { get; private set; }
        public bool Walkablegrav { get; private set; }

        public Tile(Color color, Vector2f position, bool walkablegrav,bool walkable, Vector2f size)
        {
            shape = new RectangleShape(size);
            shape.FillColor = color;
            shape.Position = position;
            Walkable = walkable;
            Walkablegrav = walkablegrav;
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(shape);
        }
    }
}

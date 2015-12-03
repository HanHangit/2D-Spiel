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
        
        public bool Walkable { get; private set; }
        public bool Walkablegrav { get; private set; }

        public Tile(Color color, Vector2f position, bool walkablegrav,bool walkable, Vector2f size)
        {
            Walkable = walkable;
            Walkablegrav = walkablegrav;
        }
    }
}

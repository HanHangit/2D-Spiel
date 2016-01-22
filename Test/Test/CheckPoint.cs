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
    class CheckPoint
    {
        Vector2f Position = new Vector2f(0, 0);

        public CheckPoint(Vector2f posVector)
        {
            Position = posVector;
        }

        public CheckPoint(float posX, float posY)
        {
            Position.X = posX;
            Position.Y = posY;
        }

        public float getPostionX()
        {
            return this.Position.X;
        }

        public float getPostionY()
        {
            return this.Position.Y;
        }

        public Vector2f getPositionVector2f()
        {
            return this.Position;
        }
    }
}

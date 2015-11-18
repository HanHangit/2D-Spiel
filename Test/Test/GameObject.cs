using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    abstract class GameObject
    {
        public Sprite sprite;
        protected Texture textur;
        protected String auswahl;
        public Vector2f MovingDirection { get; protected set; }
        protected float baseMovementSpeed;
        protected float MovementSpeed;
        protected float baseGravitationSpeed;
        public float GravitationSpeed;
        public float baseGravitationAbsolut;
        public float GravitationAbsolut;
        public bool jumptrue;
        public Vector2f wind;
        public Vector2f Position { get { return sprite.Position; } }
        public Vector2f Size { get { return new Vector2f(sprite.TextureRect.Width * sprite.Scale.X, sprite.TextureRect.Height * sprite.Scale.Y); } }
        public TimeSpan time;
        public bool isMoving;

        protected void Move()
        {
            //evaluate the direction from this position to the given one. Math \(^^)/
            Vector2f direction = MovingDirection;

            //evaluate the length of the direction vector. Math \(^^)/
            float length = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);

            //norming the direction vector, so it have the length of 1. Math \(^^)/
            if (length != 0)
                direction = direction / length;

            //adding a percentage of the direction to the position. guess what comes now^^ Math \(^^)/
            //isMoving = Program.map.IsWalkable(this);
            //if(isMoving)
                sprite.Position += direction * MovementSpeed;
        }

        public abstract void Update(GameTime gTime);
        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
        }
    }
}

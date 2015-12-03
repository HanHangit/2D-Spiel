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
        protected Texture textur; //Textur für nach rechts gehen
        protected Texture textur1; //Textur für nach links gehen
        protected String auswahl;
        public bool a;
        protected Color col;
        public Vector2f MovingDirection { get; set; }
        public float baseMovementSpeed; 
        protected float MovementSpeed;
        public Vector2f wind; //Window - Fenster
        public Vector2f Position { get { return sprite.Position; } }
        public Vector2f Size { get { return new Vector2f(sprite.TextureRect.Width * sprite.Scale.X, sprite.TextureRect.Height * sprite.Scale.Y); } }
        public TimeSpan time;
        public TimeSpan special;
        public bool isMoving;
        public bool isMovingright;
        public bool isMovingleft;

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

        protected bool collplayer()
        {
            int k = 18;
            float x = Program.player.Position.X - Program.player.sprite.TextureRect.Width + k;
            float y = Program.player.Position.Y - Program.player.sprite.TextureRect.Height + k;
            float sx = Program.player.Position.X + Program.player.sprite.TextureRect.Width - k;
            float sy = Program.player.Position.Y + Program.player.sprite.TextureRect.Height - k;

            if (x < Position.X && Position.X < sx && y < Position.Y && Position.Y < sy) //Collision
            {
                    return true;

            }
            return false;
        }


        public abstract void Update(GameTime gTime);
        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
        }
    }
}

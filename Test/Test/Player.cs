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
    class Player
    {
        Texture textur;
        Sprite sprite;

        public Player()
        {
            textur = new Texture("cookie.png");
            
            sprite = new Sprite(textur);
            sprite.Origin = new Vector2f (textur.Size.X / 4, textur.Size.Y / 2);
        }

        public Vector2f position()
        {
            return sprite.Position;          
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }

        public Vector2f direction(Vector2f a,Vector2f b)
        {
            return b - a;
        }

        public float abstand(Vector2f dir)
        {
            return System.Convert.ToSingle(Math.Sqrt(Math.Pow(dir.X, 2) + Math.Pow(dir.Y, 2)));
        }

        public bool collision()
        {
            return true;
        }

        public void animation()
        {
            if (sprite.TextureRect.Left > 150)
                sprite.TextureRect = new IntRect(0, 0, 56, 57);
            else if (sprite.TextureRect.Left < 5)
                sprite.TextureRect = new IntRect(59, 0, 56, 57);
            else if (sprite.TextureRect.Left < 60)
                sprite.TextureRect = new IntRect(117, 0, 56, 57);
            else
                sprite.TextureRect = new IntRect(176, 0, 56, 57);
            sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);


        }



        public void move(Vector2u window, float a)
        {

           

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && sprite.Position.X > sprite.Origin.X)
            {
                if (collision())
                {
                    sprite.Position += new Vector2f(-a, 0);
                }
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && sprite.Position.X < window.X - sprite.Origin.X)
            {
                if (collision())
                {
                    sprite.Position += new Vector2f(a, 0);
                }

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down) && sprite.Position.Y < window.Y - sprite.Origin.Y)
            {
                if (collision())
                {
                    sprite.Position += new Vector2f(0, a);
                }
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && sprite.Position.Y > sprite.Origin.Y)
            {
                if (collision())
                {
                    sprite.Position += new Vector2f(0, -a);
                }
            }
        }
    }
}

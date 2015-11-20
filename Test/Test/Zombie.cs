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
    class Zombie : GameObject
    {

        public Zombie(Vector2f pos)
        {
            textur = new Texture("zombie.png");
            sprite = new Sprite(textur);
            MovementSpeed = 0.4f;
            sprite.Origin = new Vector2f(textur.Size.X / 2, textur.Size.Y / 2);
            setPosition(pos);
        }

        public override void Update(GameTime gTime)
        {
            animation(gTime);
            moving();
        }

        public void animation(GameTime gTime)
        {
            time += gTime.Ellapsed;
            if (time.Milliseconds >= 300)
            {
                /*
                if (isMovingright)
                {
                    sprite.Texture = textur;
                }
                else if (isMovingleft)
                {
                    sprite.Texture = textur1;
                }
                */
                time = new TimeSpan(0);
                if (sprite.TextureRect.Left > 100)
                    sprite.TextureRect = new IntRect(0, 0, 39, 68);
                else if (sprite.TextureRect.Left < 5)
                    sprite.TextureRect = new IntRect(39, 0, 39, 68);
                else if (sprite.TextureRect.Left < 60)
                    sprite.TextureRect = new IntRect(78, 0, 39, 68);
                else
                    sprite.TextureRect = new IntRect(116, 0, 39, 68);
            }
            sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);
        }

        private void setPosition(Vector2f pos)
        {
            sprite.Position = pos;
        }

        private void moving()
        {
            while(Program.map.IsWalkablegrav(this))
            {
                sprite.Position += new Vector2f(0,0.05f);
            }
        }
    }
}

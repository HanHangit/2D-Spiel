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
    class Geist : GameObject
    {
         public Geist ()
        {
            textur = new Texture("geist.png");
            sprite = new Sprite(textur);
            MovementSpeed = 0.3f;
            sprite.Origin = new Vector2f(textur.Size.X / 2, textur.Size.Y / 2);
         }
        public override void Update(GameTime gTime)
        {
            verfolgen();
            animation(gTime);
        }

        public void animation(GameTime gTime)
        {
            time += gTime.Ellapsed;
            if (time.Milliseconds >= 400)
            {
                time = new TimeSpan(0);   
                if (sprite.TextureRect.Left > 5)
                    sprite.TextureRect = new IntRect(2, 2, 48, 48);
                else
                    sprite.TextureRect = new IntRect(49, 2, 48, 48);
                sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2 , sprite.TextureRect.Height / 2);
            }
        }

        public void verfolgen()
        {
            MovingDirection = Program.player.Position - Position;
            Move();
        }

        public static bool collision()
        {
            return false;
        }
    }
}

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
    class Speed : GameObject
    {
        public bool a;
        public Speed(Vector2f position)
        {
            textur = new Texture("Speed.png");
            sprite = new Sprite(textur);
            setposition(position);
            a = true;    
        }

        public void animation(GameTime gTime)
        {
            time += gTime.Ellapsed;
            if (time.Milliseconds >= 100)
            {
                time = new TimeSpan(0);
                if (sprite.TextureRect.Left > 5)
                    sprite.TextureRect = new IntRect(0, 0, 57, 46);
                else
                    sprite.TextureRect = new IntRect(57, 0, 57, 46);
                //sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);
            }
        }

        public override void Update(GameTime gTime)
        {
            animation(gTime);
            activate();
        }

        private void setposition(Vector2f position)
        {
            sprite.Position = position;   
        }

        private void activate()
        {

            float x = Program.player.Position.X - Program.player.sprite.TextureRect.Width;
            float y = Program.player.Position.Y - Program.player.sprite.TextureRect.Height;
            float sx = Program.player.Position.X + Program.player.sprite.TextureRect.Width;
            float sy = Program.player.Position.Y + Program.player.sprite.TextureRect.Height;

            if (x < Position.X && Position.X < sx && y < Position.Y && Position.Y < sy )
            {
                a = false;
                Program.player.baseMovementSpeed *= 2;
            }
        }
    }
}

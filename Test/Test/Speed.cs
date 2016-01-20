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
        private TimeSpan dauer;
        public Speed(Vector2f position)
        {
            textlaufenrechts = new Texture("Energy.png");
            sprite = new Sprite(textlaufenrechts);
            setposition(position);
            a = true;
            dauer = new TimeSpan(0, 0, 5);
            special = new TimeSpan(0);
        }

        public void animation(GameTime gTime)
        {
            time += gTime.Ellapsed;
            if (time.Milliseconds >= 100)
            {
                time = new TimeSpan(0);
                if (sprite.TextureRect.Left > 12)
                    sprite.TextureRect = new IntRect(12, 0, 30, 64);
                else
                    sprite.TextureRect = new IntRect(62, 0, 30, 64);
                //sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);
            }
        }

        public override void Update(GameTime gTime)
        {
            
            animation(gTime);
            if (special.Ticks == 0)
                activate();
            else
                deactivate(gTime);
        }

        private void setposition(Vector2f position)
        {
            sprite.Position = position;   
        }
        private void activate()
        {
            if (collplayer())
            {
                a = false;
                special = new TimeSpan(0, 0, 5);
                Map01.player.baseMovementSpeed *= 2;
            }
        }

        private void deactivate(GameTime gTime)
        {
            special = special.Subtract(new TimeSpan(gTime.Ellapsed.Ticks));
            //Console.WriteLine(special.Seconds);
            if (special.Ticks < 2)
            {
                special = new TimeSpan(0);
                Map01.player.baseMovementSpeed /= 2;
            }
        }
    }
}

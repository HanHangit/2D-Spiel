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
    class Unsterblich : GameObject
    {
        public bool a;
        public Unsterblich(Vector2f position)
        {
            textur = new Texture("invis.png");
            sprite = new Sprite(textur);
            setposition(position);
            a = true;
            special = new TimeSpan(0);
        }

        public override void Update(GameTime gTime)
        {

            animation(gTime);
            if (special.Ticks == 0)
                activate();
            else
                deactivate(gTime);
        }


        public void animation(GameTime gTime)
        {
            time += gTime.Ellapsed;
            if (time.Milliseconds >= 100)
            {
                time = new TimeSpan(0);
                if (sprite.TextureRect.Left > 50)
                    sprite.TextureRect = new IntRect(10, 0, 30, 49);
                else
                    sprite.TextureRect = new IntRect(57, 0, 30, 49);
                sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);
            }
        }

        private void setposition(Vector2f position)
        {
            sprite.Position = position;
        }

        private void activate()
        {
            if (collplayer() && Program.player.sterblich)
            { 
                a = false;
                    special = new TimeSpan(0, 0, 10);
                    Program.player.sterblich = false;
                
            }
        }

        private void deactivate(GameTime gTime)
        {
            special = special.Subtract(new TimeSpan(gTime.Ellapsed.Ticks));
            Console.WriteLine(special.Seconds);
            if (special.Ticks < 2)
            {
                special = new TimeSpan(0);
                Program.player.sterblich = true;
            }
        }
    }
}

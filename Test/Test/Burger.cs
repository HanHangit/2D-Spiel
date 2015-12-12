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
    class Burger : GameObject
    {
        private TimeSpan dauer;
        public Burger(Vector2f pos)
        {
            a = true;
            dauer = new TimeSpan(0, 0, 5);
            textlaufenrechts = new Texture("Burger.png");
            sprite = new Sprite(textlaufenrechts);
            MovementSpeed = 0.4f;
            MovingDirection = new Vector2f(1, 0);
            sprite.TextureRect = new IntRect(0, 0, 39, 68);
            sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);
            setPosition(pos);
        }

        public void setPosition(Vector2f pos)
        {
            sprite.Position = pos;
        }

        public void animation(GameTime gTime)
        {
            time += gTime.Ellapsed;
            if (time.Milliseconds >= 100)
            {
                time = new TimeSpan(0);
                if (sprite.TextureRect.Left > 150)
                    sprite.TextureRect = new IntRect(0, 0, 56, 39);
                else if (sprite.TextureRect.Left < 5)
                    sprite.TextureRect = new IntRect(56, 0, 56, 39);
                else if (sprite.TextureRect.Left < 60)
                    sprite.TextureRect = new IntRect(121, 0, 56, 39);
                else
                    sprite.TextureRect = new IntRect(187, 0, 56, 39);
                sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);
            }
        }

        public override void Update(GameTime gTime)
        {
            animation(gTime);
            if (a)
                activate(); //Checkt die Collision mit dem Player.
            else
                deactivate(gTime); //Testet ob die Aktion(Verlangsamung...) abgelaufen ist.
        }

        private void activate()
        {
            if (collplayer())
            {
                a = false;
                special = new TimeSpan(0, 0, 5);
                Map01.player.baseMovementSpeed /= 2;
            }
        }

        private void deactivate(GameTime gTime)
        {
            special = special.Subtract(new TimeSpan(gTime.Ellapsed.Ticks));
            if (special.Ticks < 2)
            {
                special = new TimeSpan(0);
                Map01.player.baseMovementSpeed *= 2;
            }
        }
    }
}

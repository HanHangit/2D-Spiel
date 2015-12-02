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
        public Geist()
        {
            textur = new Texture("geist.png");
            sprite = new Sprite(textur);
            MovementSpeed = 0.6f;
            sprite.Origin = new Vector2f(textur.Size.X / 2, textur.Size.Y / 2);
            col = sprite.Color;
            a = true;
        }
        public override void Update(GameTime gTime)
        {
            verfolgen();
            animation(gTime);
            if (a)
                activate();
            else
                deactivate(gTime);
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
                sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);
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

        public void setPosition(Vector2f position)
        {
            sprite.Position = position;
        }

        private void activate()
        {

            if (collplayer() && Program.player.sterblich)
            {
                a = false; //Objekt wird deaktiviert
                special = new TimeSpan(0, 0, 5); //Zeit wie lange die Aktion(Verlangsamung...) dauern soll
                MovementSpeed = 0;
                Program.player.bewegungumdrehen *= -1;
                sprite.Color = new Color(sprite.Color.R, sprite.Color.G, sprite.Color.B, 50); //Objekt wird zu 50% transparent gemacht
            }



        }

        private void deactivate(GameTime gTime)
        {
            special = special.Subtract(new TimeSpan(gTime.Ellapsed.Ticks));
            Console.WriteLine(special.Seconds);
            if (special.Ticks < 2) //"Knapp daneben" Zitat Matthis
            {
                a = true;
                special = new TimeSpan(0);
                //Program.player.baseMovementSpeed *= -1;
                MovementSpeed = 0.6f;
                Program.player.bewegungumdrehen *= -1;
                sprite.Color = col; //Farbe wird zurückgesetzt.
            }
        }


    }
}

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
        private TimeSpan dauer;
        public Zombie(Vector2f pos)
        {
            //TODO: neuen Constructor: Erst wenn Spieler in der Nähe ist, wird der Zombie "aktiviert"
            a = true;
            dauer = new TimeSpan(0, 0, 5);
            textlaufenrechts = new Texture("zombieB.png");
            textlaufenlinks = new Texture("zombieB.png");
            sprite = new Sprite(textlaufenrechts);
            MovementSpeed = 0.4f;
            baseMovementSpeed = 0.1f; //Geschwindigkeit des Gegners Bitte Hier Ändern!
            MovingDirection = new Vector2f(1, 0);
            sprite.TextureRect = new IntRect(0, 0, 39, 68);
            sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);
            setPosition(pos);
            col = sprite.Color;
        }

        public override void Update(GameTime gTime)
        {
            MovementSpeed = baseMovementSpeed * gTime.Ellapsed.Milliseconds;
            animation(gTime);
            moving();
            if (a)  
                activate(); //Checkt die Collision mit dem Player.
            else
                deactivate(gTime); //Testet ob die Aktion(Verlangsamung...) abgelaufen ist.
        }

        public void animation(GameTime gTime)
        {
            time += gTime.Ellapsed;
            if (time.Milliseconds >= 300) //Animationsgeschwindigkeit
            {
                if (isMovingright)
                {
                    sprite.Texture = textlaufenrechts;
                    
                }
                else if (isMovingleft)
                {
                    sprite.Texture = textlaufenlinks;
                }
                time = new TimeSpan(0);
                if (sprite.TextureRect.Left > 50)
                    sprite.TextureRect = new IntRect(0, 0, 51, 61);
                else if (sprite.TextureRect.Left < 5)
                    sprite.TextureRect = new IntRect(51, 0, 51, 61);
            }
            sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);
        }

        private void setPosition(Vector2f pos)
        {
            sprite.Position = pos;
            while (Map01.map.IsWalkablegrav(this)) //Objekt wird solange nach unten bewegt bis ein schwarzer BOden erreicht ist.
            {
                sprite.Position += new Vector2f(0, 5f);
            }
        }

        private void moving()
        {
            if (Map01.map.IsWalkablegrav(this) || !Map01.map.IsWalkable(this))
            {
                MovingDirection *= -1;
            }
            if (MovingDirection.X > 0)
            {
                isMovingright = true;
                isMovingleft = false;
            }
            else
            {
                isMovingleft = true;
                isMovingright = false;
            }
            Move();
        }
        protected void activate()
        {
            //TODO: Stirbt wenn berührt
            //TODO: Player wird betäubt
            if (collplayer() && Map01.player.sterblich) //Collision
            {
                    a = false; //Objekt wird deaktiviert
                Map01.player.resetpos();
                    sprite.Color = new Color(sprite.Color.R, sprite.Color.G, sprite.Color.B, 50); //Objekt wird zu 50% transparent gemacht
                special = new TimeSpan(0, 0, 5);
            }
        }

        protected void deactivate(GameTime gTime)
        {
            special = special.Subtract(new TimeSpan(gTime.Ellapsed.Ticks));
            //Console.WriteLine(special.Seconds);
            if (special.Ticks < 2) //"Knapp daneben" Zitat Matthis
            {
                a = true;
                special = new TimeSpan(0);
                sprite.Color = col; //Farbe wird zurückgesetzt.
            }
        }
    }
}

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
            a = true;
            dauer = new TimeSpan(0, 0, 5);
            textur = new Texture("zombie.png");
            sprite = new Sprite(textur);
            MovementSpeed = 0.4f;
            MovingDirection = new Vector2f(1, 0);
            sprite.TextureRect = new IntRect(0, 0, 39, 68);
            sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);
            setPosition(pos);
            col = sprite.Color;
        }

        public override void Update(GameTime gTime)
        {
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
            while (Program.map.IsWalkablegrav(this)) //Objekt wird solange nach unten bewegt bis ein schwarzer BOden erreicht ist.
            {
                sprite.Position += new Vector2f(0, 0.05f);
            }
        }

        private void moving()
        {

            if (Program.map.IsWalkablegrav(this) || !Program.map.IsWalkable(this))
            {
                MovingDirection *= -1;
            }
            
            Move();
        }
        protected void activate()
        {
            if (collplayer() && Program.player.sterblich) //Collision
            {
                    Program.player.baseMovementSpeed /= 2;
                    a = false; //Objekt wird deaktiviert
                    special = new TimeSpan(0, 0, dauer.Seconds); //Zeit wie lange die Aktion(Verlangsamung...) dauern soll
                    //Program.player.baseMovementSpeed *= -1;
                    sprite.Color = new Color(sprite.Color.R, sprite.Color.G, sprite.Color.B, 50); //Objekt wird zu 50% transparent gemacht
            }
        }

        protected void deactivate(GameTime gTime)
        {
            special = special.Subtract(new TimeSpan(gTime.Ellapsed.Ticks));
            Console.WriteLine(special.Seconds);
            if (special.Ticks < 2) //"Knapp daneben" Zitat Matthis
            {
                a = true;
                special = new TimeSpan(0);
                //Program.player. *= -1;
                Program.player.baseMovementSpeed *= 2;
                sprite.Color = col; //Farbe wird zurückgesetzt.
            }
        }
    }
}

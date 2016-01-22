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
        private int richtung = 1;
        private int aktion;
        private Vector2f pos1, pos2;
        public Geist()
        {
            aktion = 0; //0 bedeutet verfolgen
            textlaufenrechts = new Texture("geistbier.png");
            sprite = new Sprite(textlaufenrechts);
            MovementSpeed = 0.6f;
            sprite.Origin = new Vector2f(textlaufenrechts.Size.X / 2, textlaufenrechts.Size.Y / 2);
            col = sprite.Color;
            a = true;
        }

        public Geist(Vector2f punkt1, Vector2f punkt2)
        {
            Vector2f help;
            if(punkt1.X > punkt2.X || punkt1.Y > punkt2.Y)
            {
                help = punkt1;
                punkt1 = punkt2;
                punkt2 = help;
            }

            pos1 = punkt1;
            pos2 = punkt2;
            aktion = 1; //1 bedeutet Bewegung zwischen zwei Punkten.
            textlaufenrechts = new Texture("geistbier.png");
            sprite = new Sprite(textlaufenrechts);
            MovementSpeed = 0.6f;
            sprite.Origin = new Vector2f(textlaufenrechts.Size.X / 2, textlaufenrechts.Size.Y / 2);
            col = sprite.Color;
            setPosition(punkt1);
            a = true;
        }
        public override void Update(GameTime gTime)
        {
            if (aktion == 0)
                verfolgen();
            if (aktion == 1)
                bewegung();
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
                if (sprite.TextureRect.Left > 20)
                    sprite.TextureRect = new IntRect(6, 2, 60, 68);
                else
                    sprite.TextureRect = new IntRect(70, 2, 60, 68);
                sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);
            }
        }

        public void verfolgen()
        {
            MovingDirection = Map01.player.Position - Position;
            Move();
        }

        public void bewegung()
        {
            if (Position.X > pos2.X || Position.Y > pos2.Y)
                richtung = -1;
            else if (Position.X < pos1.X || Position.Y < pos1.Y)
                richtung = 1;
            MovingDirection = (pos2 - pos1) * richtung;
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

            if (collplayer() && Map01.player.sterblich)
            {
                Map01.player.score += 10; 
                //TODO: bewegungumdrehen von Map unabhängig machen
                a = false; //Objekt wird deaktiviert
                special = new TimeSpan(0, 0, 5); //Zeit wie lange die Aktion(Verlangsamung...) dauern soll
                MovementSpeed = 0;
                Map01.player.bewegungumdrehen *= -1;
                sprite.Color = new Color(sprite.Color.R, sprite.Color.G, sprite.Color.B, 50); //Objekt wird zu 50% transparent gemacht
            }



        }

        private void deactivate(GameTime gTime)
        {
            special = special.Subtract(new TimeSpan(gTime.Ellapsed.Ticks));
            if (special.Ticks < 2) //"Knapp daneben" Zitat Matthis; Hö ?
            {
                a = true;
                special = new TimeSpan(0);
                //Map1.player.baseMovementSpeed *= -1;
                MovementSpeed = 0.6f;
                 Map01.player.bewegungumdrehen *= -1;
                sprite.Color = col; //Farbe wird zurückgesetzt.
            }
        }


    }
}

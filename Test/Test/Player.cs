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
    class Player : GameObject
    {

        public Player(String bild, Vector2f startPosition)
        {
            auswahl = bild;
            if (auswahl == "Cookie")
                textur = new Texture("cookie.png");
            if (auswahl == "Tofu")
                textur = new Texture("tofu.png");

            baseMovementSpeed = 0.4f;
            GravitationAbsolut = 0f;
            baseGravitationSpeed = 0.003f;
            sprite = new Sprite(textur);
            sprite.Position = startPosition;
            sprite.Origin = new Vector2f (textur.Size.X / 4, textur.Size.Y / 2);
        }

        public void animation(GameTime gTime)
        {
            time += gTime.Ellapsed;
            if (time.Milliseconds >= 50)
            {
                time = new TimeSpan(0);
                if (auswahl == "Cookie")
                {
                    if (sprite.TextureRect.Left > 150)
                        sprite.TextureRect = new IntRect(0, 0, 56, 57);
                    else if (sprite.TextureRect.Left < 5)
                        sprite.TextureRect = new IntRect(59, 0, 56, 57);
                    else if (sprite.TextureRect.Left < 60)
                        sprite.TextureRect = new IntRect(117, 0, 56, 57);
                    else
                        sprite.TextureRect = new IntRect(176, 0, 56, 57);
                }
                if (auswahl == "Tofu")
                {
                    if (sprite.TextureRect.Left > 150)
                        sprite.TextureRect = new IntRect(4, 0, 48, 78);
                    else if (sprite.TextureRect.Left < 5)
                        sprite.TextureRect = new IntRect(52, 0, 48, 78);
                    else if (sprite.TextureRect.Left < 60)
                        sprite.TextureRect = new IntRect(104, 0, 48, 78);
                    else
                        sprite.TextureRect = new IntRect(153, 0, 48, 78);
                }
            }

            sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);


        }

        void Sprung()
        {
            if (jumptrue == false)
            {
                GravitationAbsolut = -2f;
                jumptrue = true;
            }
        }
        void KeyboardInput()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                Sprung();
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                MovingDirection = new Vector2f(-1, MovingDirection.Y);
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                MovingDirection = new Vector2f(1, MovingDirection.Y);
            else
                MovingDirection = new Vector2f(0, MovingDirection.Y);
        }

        public override void Update(GameTime gTime)
        {
            GravitationSpeed = baseGravitationSpeed * gTime.Ellapsed.Milliseconds;
            MovementSpeed = baseMovementSpeed * gTime.Ellapsed.Milliseconds;
            KeyboardInput();
            Move();
            Gravitation();
        }

        public void Gravitation()
        {
            if(GravitationAbsolut <= 2f)
            GravitationAbsolut += GravitationSpeed;
            if (collmap() || GravitationAbsolut <= 0)
            {
                sprite.Position += new Vector2f(0, GravitationAbsolut);
            }
            else
            {
                jumptrue = false;
                GravitationAbsolut = -0.01f;
            }
        }

        public bool collmap()
        {
            return Program.map.IsWalkablegrav(this);
        }
    }
}

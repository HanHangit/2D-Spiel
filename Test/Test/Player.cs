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
        public bool jumptrue;
        protected float baseGravitationSpeed;
        public float GravitationSpeed;
        public float baseGravitationAbsolut;
        public float GravitationAbsolut;
        public View view;
        public Player(String bild, Vector2f startPosition)
        {
            auswahl = bild;
            if (auswahl == "Cookie")
            {
                textur = new Texture("cookie.png"); //Textur nach rechts
                textur1 = new Texture("cookie2.png"); //Textur nach links
            }
            if (auswahl == "Tofu")
            {
                textur = new Texture("tofu.png");
                textur1 = new Texture("tofu2.png");
            }


            baseMovementSpeed = 0.25f;
            GravitationAbsolut = 0f;
            baseGravitationSpeed = 0.03f;
            baseGravitationAbsolut = -10f;
            sprite = new Sprite(textur);
            sprite.Position = startPosition;
            sprite.Origin = new Vector2f (textur.Size.X / 4, textur.Size.Y / 2);
            view = new View(new Vector2f(0,0),new Vector2f(800,600));
        }

        public void animation(GameTime gTime)
        {
            time += gTime.Ellapsed;
            if (time.Milliseconds >= 50 && isMoving)
            {
                if(isMovingright)
                {
                    sprite.Texture = textur;
                }
                else if(isMovingleft)
                {
                    sprite.Texture = textur1;
                }
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

        void Sprung(GameTime gTime) 
        {
            if (jumptrue == false)
            {
                GravitationAbsolut = baseGravitationAbsolut;
                //GravitationAbsolut = -1f;
                jumptrue = true;
            }
        }
        void KeyboardInput(GameTime gTime)
        {
            isMoving = true;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                Sprung(gTime);
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                MovingDirection = new Vector2f(-10, 0);
                isMovingright = false;
                isMovingleft = true;

            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                MovingDirection = new Vector2f(10, 0);
                isMovingright = true;
                isMovingleft = false;
            }
            else
            {
                MovingDirection = new Vector2f(0, 0);
                isMoving = false;
                isMovingleft = false;
                isMovingright = false;
            }
        }

        public override void Update(GameTime gTime)
        {
            GravitationSpeed = baseGravitationSpeed * gTime.Ellapsed.Milliseconds;
            MovementSpeed = baseMovementSpeed * gTime.Ellapsed.Milliseconds;
            KeyboardInput(gTime);
            if(Program.map.IsWalkable(this))
                Move();
            Gravitation(gTime);
        }

        public void Gravitation(GameTime gTime)
        {
            int x = 2;
            if(GravitationAbsolut <= 10f)
                GravitationAbsolut += GravitationSpeed;
            MovementSpeed =  GravitationAbsolut;
            MovingDirection = new Vector2f(0, x);
            if (collmap() || GravitationAbsolut < 0)
            {
                Move();
                //sprite.Position += new Vector2f(0, GravitationAbsolut);
            }
            else
            {
                jumptrue = false;
                GravitationAbsolut = 0f;
            }
        }

        public bool collmap()
        {
           return Program.map.IsWalkablegrav(this);
        }

        public void setview(RenderWindow window)
        {
            Vector2f camPos = Position;
            if (camPos.X < 400)
            {
                camPos.X = 400;
            }
            else if (camPos.X > 2600)
            {
                camPos.X = 2600;
            }

            if (camPos.Y < 300)
            {
                camPos.Y = 300;
            }
            else if (camPos.Y>700)
            {
                camPos.Y = 700;
            }
            view.Center = camPos;
            window.SetView(view);
        }
    }
}

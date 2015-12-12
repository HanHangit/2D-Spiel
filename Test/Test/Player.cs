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
        public int jumptrue;
        public int basejumptrue;
        public bool jump;
        public bool sterblich = true;
        protected float baseGravitationSpeed;
        public float GravitationSpeed;
        public float baseGravitationAbsolut;
        public float GravitationAbsolut;
        public View view;
        public float bewegungumdrehen;
        private bool animrepeat;
        public Player(String bild, Vector2f startPosition)
        {
            //TODO: Kann sich erst bewegen nach Ende eines Timers(Start), Animation dazu
            jumptrue = 1;
            basejumptrue = 1;
            jump = true;
            auswahl = bild;
            
            if (auswahl == "Cookie")
            {
                //TODO: Ordner-Strukturen einrichten: Bilder/Animation in einen Ordner packen und von dort aufrufen
                textlaufenrechts = new Texture("cookie.png"); //Textur nach rechts
                textlaufenlinks = new Texture("cookie2.png"); //Textur nach links
                textjumprechts = new Texture("cookie.png");
                textjumplinks = new Texture("cookie2.png");
                textidle = new Texture("cookie.png");
            }
            if (auswahl == "Tofu")
            {
                textlaufenrechts = new Texture("tofu.png");
                textlaufenlinks = new Texture("tofu2.png");
                textjumprechts = new Texture("tofu.png");
                textjumplinks = new Texture("tofu2.png");
                textidle = new Texture("tofu.png");
            }
            if (auswahl == "Cookie2")
            {
                textlaufenrechts = new Texture("Cookie-animation/laufenrechts.png");
                textlaufenlinks = new Texture("Cookie-animation/laufenlinks.png");
                textjumprechts = new Texture("Cookie-animation/hüpfenrechts.png");
                textjumplinks = new Texture("Cookie-animation/hüpfenlinks.png");
                textidle = new Texture("Cookie-animation/idle.png");
            }
            System.Console.WriteLine(auswahl);
            baseMovementSpeed = 0.5f;
            GravitationAbsolut = 0f;
            baseGravitationSpeed = 0.03f;
            baseGravitationAbsolut = -10f;
            sprite = new Sprite(textlaufenrechts);
            sprite.Position = startPosition;
            sprite.Origin = new Vector2f (textlaufenrechts.Size.X / 4, textlaufenrechts.Size.Y / 2);
            sprite.TextureRect = new IntRect(0, 0, 0, 0);
            view = new View(new Vector2f(0,0),new Vector2f(800,600));
            bewegungumdrehen = 1;
            a = true;
            animrepeat = true;
        }

        public void animation(GameTime gTime)
        {
            int[] x = null, y = null, w = null, h = null;
            int i = 0, animtime = 0;
            time += gTime.Ellapsed;
            //TODO: Abfrage für Animation laden/starten wenn im Ziel
            //TODO: Animation vervollständigen
            //TODO: Abfrage, wenn Player beschleunigt!?
            if (GravitationAbsolut != 0)
            {
                if (isMovingright)
                {
                    sprite.Texture = textjumprechts;
                    if (auswahl == "Tofu")
                    {
                        x = new int[] { 4, 52, 104, 153 }; //X-Koordinaten von denen ausgeschnitten werden 
                        y = new int[] { 0, 0, 0, 0 }; //Y-Koordinaten von denen ausgeschnitten werden soll
                        w = new int[] { 48, 48, 48, 48 }; //Länder der Bilder
                        h = new int[] { 78, 78, 78, 78 }; //Höher der Bilder
                        animtime = 300; //Dauer der Animation
                        animrepeat = true; //Ob die Animation wiederholt werden soll
                    }
                    if (auswahl == "Cookie")
                    {
                        x = new int[] { 0, 59, 117, 176 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 56, 56, 56, 56 };
                        h = new int[] { 58, 58, 58, 58 };
                        animtime = 300;
                        animrepeat = true;
                    }
                    if (auswahl == "Cookie2")
                    {
                        x = new int[] { 0, 41, 80 };
                        y = new int[] { 0, 0, 0 };
                        w = new int[] { 41, 39, 72 };
                        h = new int[] { 61, 61, 61 };
                        animtime = 300;
                        animrepeat = false;
                    }
                }
                else //if(isMovingleft)
                {
                    sprite.Texture = textjumplinks;
                    if (auswahl == "Tofu")
                    {
                        x = new int[] { 4, 52, 104, 153 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 48, 48, 48, 48 };
                        h = new int[] { 78, 78, 78, 78 };
                        animtime = 300;
                        animrepeat = true;
                    }
                    if (auswahl == "Cookie")
                    {
                        x = new int[] { 0, 54, 114, 171 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 54, 60, 54, 60 };
                        h = new int[] { 58, 58, 58, 58 };
                        animtime = 300;
                        animrepeat = true;
                    }
                    if (auswahl == "Cookie2")
                    {
                        x = new int[] { 0, 41, 80 };
                        y = new int[] { 0, 0, 0 };
                        w = new int[] { 41, 39, 72 };
                        h = new int[] { 61, 61, 61 };
                        animtime = 300;
                        animrepeat = false;
                    }
                }
            }
            else
            {
                if (isMovingright)
                {
                    sprite.Texture = textlaufenrechts;
                    if (auswahl == "Tofu")
                    {
                        x = new int[] { 4, 52, 104, 153 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 48, 48, 48, 48 };
                        h = new int[] { 78, 78, 78, 78 };
                        animtime = 300;
                        animrepeat = true;
                    }
                    if (auswahl == "Cookie")
                    {
                        x = new int[] { 0, 59, 117, 176 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 56, 56, 56, 56 };
                        h = new int[] { 58, 58, 58, 58 };
                        animtime = 300;
                        animrepeat = true;
                    }
                    if (auswahl == "Cookie2")
                    {
                        x = new int[] { 1, 44, 87 };
                        y = new int[] { 0, 0, 0 };
                        w = new int[] { 45, 45, 43 };
                        h = new int[] { 64, 64, 64 };
                        animtime = 100;
                        animrepeat = true;
                    }
                }
                else if (isMovingleft)
                {
                    sprite.Texture = textlaufenlinks;
                    if (auswahl == "Tofu")
                    {
                        x = new int[] { 4, 52, 104, 153 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 48, 48, 48, 48 };
                        h = new int[] { 78, 78, 78, 78 };
                        animtime = 300;
                        animrepeat = true;
                    }
                    if (auswahl == "Cookie")
                    {
                        x = new int[] { 0, 54, 114, 171 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 54, 60, 54, 60};
                        h = new int[] { 58, 58, 58, 58 };
                        animtime = 300;
                        animrepeat = true;
                    }
                    if (auswahl == "Cookie2")
                    {
                        x = new int[] { 2, 44, 88 };
                        y = new int[] { 0, 0, 0 };
                        w = new int[] { 44, 44, 42 };
                        h = new int[] { 64, 64, 64 };
                        animtime = 100;
                        animrepeat = true;
                    }
                }
                else
                {
                    sprite.Texture = textidle;
                    if (auswahl == "Tofu")
                    {
                        x = new int[] { 4, 52, 104, 153 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 48, 48, 48, 48 };
                        h = new int[] { 78, 78, 78, 78 };
                        animtime = 300;
                        animrepeat = true;
                    }
                    else if (auswahl == "Cookie")
                    {
                        x = new int[] { 0, 59, 117, 176 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 56, 56, 56, 56 };
                        h = new int[] { 58, 58, 58, 58 };
                        animtime = 300;
                        animrepeat = true;
                    }
                    else if (auswahl == "Cookie2")
                    {
                        x = new int[] { 0, 67, 133, 199 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 67, 67, 67, 67 };
                        h = new int[] { 64, 61, 64, 64 };
                        animtime = 500;
                        animrepeat = true;
                    }
                }
            }

            //Console.WriteLine(checkneueanim(sprite.TextureRect, x, y, w, h));
            if (checkneueanim(sprite.TextureRect,x,y,w,h))
                sprite.TextureRect = new IntRect(x[0], y[0], w[0], h[0]);
            else
            if (time.Milliseconds >= animtime)
                {
                    time = new TimeSpan(0);
                //System.Console.WriteLine(sprite.TextureRect.Left.ToString() + "||||" + x[i]);
                while (sprite.TextureRect.Left != x[i])
                    {
                        ++i;
                    }
                //System.Console.WriteLine(i + "||" + (x.Length - 1));
                if (i == x.Length - 1 && animrepeat)
                {
                    //sprite.TextureRect = new IntRect(x[x.Length - 1], y[y.Length - 1], w[w.Length - 1], h[h.Length - 1]);
                    i = 0;
                    sprite.TextureRect = new IntRect(x[i], y[i], w[i], h[i]);
                }
                else
                {
                    if(i != x.Length - 1)
                        ++i;
                    sprite.TextureRect = new IntRect(x[i], y[i], w[i], h[i]);
                }
                System.Console.WriteLine(i);
                //System.Console.WriteLine(sprite.TextureRect.Left.ToString());
                //Console.WriteLine(checkneueanim(sprite.TextureRect, x, y, w, h));
            }
            sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);

        }

        private static bool checkneueanim(IntRect text, int[] x, int[] y, int[] w, int[] h)
        {
            int k = 0;
            for (int i = 0; i < y.Length ; i++)
            {
                if (text.Left == x[i])
                {
                    ++k;
                    break;
                }
            }
            for (int i = 0; i < y.Length ; i++)
            {
                if (text.Top == y[i])
                {
                    ++k;
                    break;
                }
            }
            for (int i = 0; i < y.Length ; i++)
            {
                if (text.Width == w[i])
                {
                    ++k;
                    break;
                }
            }
            for (int i = 0; i < y.Length ; i++)
            {
                if (text.Height == h[i])
                {
                    ++k;
                    break;
                }
            }
            if (k == 4)
                return false;
            else
                return true;
        }

        void Sprung(GameTime gTime) 
        {
            //TODO: Optimieren mit gTime
            if (jump)
            {
                GravitationAbsolut = baseGravitationAbsolut;
                //GravitationAbsolut = -1f;
                jump = false;
                --jumptrue;
            }
        }
        void KeyboardInput(GameTime gTime)
        {
            //TODO: Beschleunigung!?
            isMoving = true;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                Sprung(gTime);
            else if (jumptrue == 1)
                jump = true;
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

            MovingDirection *= bewegungumdrehen;
        }

        public override void Update(GameTime gTime)
        {
            GravitationSpeed = baseGravitationSpeed * gTime.Ellapsed.Milliseconds;
            MovementSpeed = baseMovementSpeed * gTime.Ellapsed.Milliseconds;
            KeyboardInput(gTime);
            if(Map01.map.IsWalkable(this))
                Move();
            Gravitation(gTime);
        }

        public void Gravitation(GameTime gTime)
        {
            int x = 1;
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
                jump = true;
                jumptrue = basejumptrue;
                GravitationAbsolut = 0f;
            }
        }

        public bool collmap()
        {
           return Map01.map.IsWalkablegrav(this);
        }

        public void setview(RenderWindow window)
        {
            Vector2f camPos = Position;
            Vector2f map = Map01.map.map;
            //Console.WriteLine(map.Y);
            //Console.WriteLine(map.X);
            //Console.WriteLine(window.Size.X);
            //Console.WriteLine(window.Size.Y);
            //Console.WriteLine(map.Y - window.Size.Y);
            view.Size = new Vector2f(window.Size.X,window.Size.Y);
            
            if (camPos.X < window.Size.X / 2)
            {
                camPos.X = window.Size.X / 2;
            }
            else if (camPos.X > map.X - window.Size.X / 2)
            {
                camPos.X = map.X - window.Size.X / 2;
            }

            if (camPos.Y < window.Size.Y / 2)
            {
                camPos.Y = window.Size.Y / 2;
            }
            else if (camPos.Y > map.Y - window.Size.Y / 2)
            {
                camPos.Y = map.Y - window.Size.Y / 2;
            }
            
            view.Center = camPos;
            window.SetView(view);
        }
    }
}

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
        public Player(String bild, Vector2f startPosition)
        {
            jumptrue = 1;
            basejumptrue = 1;
            jump = true;
            auswahl = bild;
            if (auswahl == "Cookie")
            {
                textlaufenrechts = new Texture("cookie.png"); //Textur nach rechts
                textlaufenlinks = new Texture("cookie2.png"); //Textur nach links
            }
            if (auswahl == "Tofu")
            {
                textlaufenrechts = new Texture("tofu.png");
                textlaufenlinks = new Texture("tofu2.png");
                textjumprechts = new Texture("tofu2.png");
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
        }

        public void animation(GameTime gTime)
        {
            int[] x = null, y = null, w = null, h = null;
            int i = 0, animtime = 0;
            time += gTime.Ellapsed;
            //TODO: Abfrage für Animation laden/starten wenn im Ziel
            //TODO: Animation vervollständigen
            if (isMovingright)
            {
                if (GravitationAbsolut != 0)
                {
                    sprite.Texture = textjumprechts;
                    if (auswahl == "Tofu")
                    {
                        x = new int[] { 4, 52, 104, 153 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 48, 48, 48, 48 };
                        h = new int[] { 78, 78, 78, 78 };
                        animtime = 300;
                    }
                    if (auswahl == "Cookie")
                    {
                        x = new int[] { 0, 59, 117, 176 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 56, 56, 56, 56 };
                        h = new int[] { 57, 57, 57, 57 };
                        animtime = 300;
                    }
                    if (auswahl == "Cookie2")
                    {
                        x = new int[] { 0, 41, 80 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 41, 39, 72 };
                        h = new int[] { 61, 61, 61 };
                        animtime = 300;
                    }
                }
                else
                {
                    sprite.Texture = textlaufenrechts;
                    if (auswahl == "Tofu")
                    {
                        x = new int[] { 4, 52, 104, 153 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 48, 48, 48, 48 };
                        h = new int[] { 78, 78, 78, 78 };
                        animtime = 300;
                    }
                    if (auswahl == "Cookie")
                    {
                        x = new int[] { 0, 59, 117, 176 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 56, 56, 56, 56 };
                        h = new int[] { 57, 57, 57, 57 };
                        animtime = 300;
                    }
                    if (auswahl == "Cookie2")
                    {
                        x = new int[] { 0, 45, 90 };
                        y = new int[] { 0, 0, 0 };
                        w = new int[] { 45, 45, 45 };
                        h = new int[] { 64, 64, 64 };
                        animtime = 300;
                    }
                }
            }
            else if (isMovingleft)
            {
                if (GravitationAbsolut != 0)
                {
                    sprite.Texture = textjumplinks;
                    if (auswahl == "Tofu")
                    {
                        x = new int[] { 4, 52, 104, 153 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 48, 48, 48, 48 };
                        h = new int[] { 78, 78, 78, 78 };
                        animtime = 300;
                    }
                    if (auswahl == "Cookie")
                    {
                        x = new int[] { 0, 59, 117, 176 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 56, 56, 56, 56 };
                        h = new int[] { 57, 57, 57, 57 };
                        animtime = 300;
                    }
                    if (auswahl == "Cookie2")
                    {
                        x = new int[] { 0, 52, 104, 153 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 48, 48, 48, 48 };
                        h = new int[] { 78, 78, 78, 78 };
                        animtime = 300;
                    }
                }
                else
                {
                    sprite.Texture = textlaufenlinks;
                    if (auswahl == "Tofu")
                    {
                        x = new int[] { 4, 52, 104, 153 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 48, 48, 48, 48 };
                        h = new int[] { 78, 78, 78, 78 };
                        animtime = 300;
                    }
                    if (auswahl == "Cookie")
                    {
                        x = new int[] { 0, 59, 117, 176 };
                        y = new int[] { 0, 0, 0, 0 };
                        w = new int[] { 56, 56, 56, 56 };
                        h = new int[] { 57, 57, 57, 57 };
                        animtime = 300;
                    }
                    if (auswahl == "Cookie2")
                    {
                        x = new int[] { 0, 45, 90 };
                        y = new int[] { 0, 0, 0 };
                        w = new int[] { 45, 45, 45 };
                        h = new int[] { 64, 64, 64 };
                        animtime = 300;
                    }
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
                }
                else if (auswahl == "Cookie")
                {
                    x = new int[] { 0, 59, 117, 176 };
                    y = new int[] { 0, 0, 0, 0 };
                    w = new int[] { 56, 56, 56, 56 };
                    h = new int[] { 57, 57, 57, 57 };
                    animtime = 300;
                }
                else if (auswahl == "Cookie2")
                {
                    x = new int[] { 0, 67, 133, 199 };
                    y = new int[] { 0, 0, 0, 0 };
                    w = new int[] { 67, 67, 67, 67 };
                    h = new int[] { 64, 64, 64, 64 };
                    animtime = 300;
                }
            }
            Console.WriteLine(checkneueanim(sprite.TextureRect, x, y, w, h));
            if (checkneueanim(sprite.TextureRect,x,y,w,h))
                sprite.TextureRect = new IntRect(x[0], y[0], w[0], h[0]);
            else
            if (time.Milliseconds >= animtime)
                {
                    time = new TimeSpan(0);
                    while (sprite.TextureRect.Left != x[i] && i < x.Length - 1)
                    {
                        ++i;
                        System.Console.WriteLine(sprite.TextureRect.Left.ToString() + "||||" + x[i]);
                    }
                    System.Console.WriteLine(i + "||" + (x.Length - 1));
                    if (i == x.Length - 1)
                    {
                        //sprite.TextureRect = new IntRect(x[x.Length - 1], y[y.Length - 1], w[w.Length - 1], h[h.Length - 1]);
                        sprite.TextureRect = new IntRect(x[0], y[0], w[0], h[0]);
                    }
                    else
                    {
                        ++i;
                        sprite.TextureRect = new IntRect(x[i], y[i], w[i], h[i]);
                    }
                }
            sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);

        }

        private static bool checkneueanim(IntRect text, int[] x, int[] y, int[] w, int[] h)
        {
            int k = 0;
            for (int i = 0; i < y.Length -1; ++i)
            {
                if (text.Left == x[i])
                {
                    ++k;
                    break;
                }
            }
            for (int i = 0; i < y.Length - 1; ++i)
            {
                if (text.Top == y[i])
                {
                    ++k;
                    break;
                }
            }
            for (int i = 0; i < y.Length - 1; ++i)
            {
                if (text.Width == w[i])
                {
                    ++k;
                    break;
                }
            }
            for (int i = 0; i < y.Length - 1; ++i)
            {
                if (text.Height == h[i])
                {
                    ++k;
                    break;
                }
            }
            //Console.WriteLine(k + "==" + y.Length);
            if (k == 4)
                return false;
            else
                return true;
        }

        void Sprung(GameTime gTime) 
        {
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

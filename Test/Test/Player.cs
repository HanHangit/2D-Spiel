﻿using System;
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
        private float maxheight;
        private int jumpingHeight;
        public bool isJumping;
        private Vector2f startpos;
        private TimeSpan deadtime;
        public int score;
        private int korrektur;

        public Player(String bild, Vector2f startPosition)
        {
            auswahl = bild;
            korrektur = 0;
            //TODO: Kann sich erst bewegen nach Ende eines Timers(Start), Animation dazu
            if (auswahl == "Cookie")
            {
                //TODO: Ordner-Strukturen einrichten: Bilder/Animation in einen Ordner packen und von dort aufrufen
                textlaufenrechts = new Texture("Cookie-animation/laufenrechts.png"); //Textur nach rechts
                textlaufenlinks = new Texture("Cookie-animation/laufenlinks.png"); //Textur nach links
                textjumprechts = new Texture("Cookie-animation/huepfenrechts.png");
                textjumplinks = new Texture("Cookie-animation/huepfenlinks.png");
                textidle = new Texture("Cookie-animation/idle.png");
                textdead = new Texture("Cookie-animation/tot.png");
            }
            if (auswahl == "Tofu")
            {
                textlaufenrechts = new Texture("tofu.png");
                textlaufenlinks = new Texture("tofu2.png");
                textjumprechts = new Texture("tofu.png");
                textjumplinks = new Texture("tofu2.png");
                textidle = new Texture("tofu.png");
                textdead = new Texture("Cookie-animation/tot.png");
            }
            if (auswahl == "Cookie2")
            {
                textlaufenrechts = new Texture("Cookie-animation/laufenrechts.png");
                textlaufenlinks = new Texture("Cookie-animation/laufenlinks.png");
                textjumprechts = new Texture("Cookie-animation/huepfenrechts.png");
                textjumplinks = new Texture("Cookie-animation/huepfenlinks.png");
                textidle = new Texture("Cookie-animation/idle.png");
                textdead = new Texture("Cookie-animation/tot.png");
                textdead = new Texture("Cookie-animation/tot.png");
            }
            score = 0;
            a = true;
            jumptrue = 1;
            basejumptrue = 1;
            jump = true;
            jumpingHeight = 300;
            startpos = startPosition;
            System.Console.WriteLine(auswahl);
            baseMovementSpeed = 0.6f;
            GravitationAbsolut = 0f;
            baseGravitationSpeed = 0.03f;
            baseGravitationAbsolut = -10f; 
            sprite = new Sprite(textlaufenrechts);
            sprite.Position = startPosition;
            sprite.Origin = new Vector2f (textlaufenrechts.Size.X / 2, textlaufenrechts.Size.Y / 2);
            sprite.TextureRect = new IntRect(0, 0, 0, 0);
            view = new View(new Vector2f(0,0),new Vector2f(800,600));
            bewegungumdrehen = 1;
            animrepeat = true;
            maxheight = sprite.Position.Y;
            isJumping = true;
            deadtime = new TimeSpan(0);
            sterblich = true;
        }

        public void animation(GameTime gTime)
        {
            int[] x = null, y = null, w = null, h = null;
            int i = 0, animtime = 0;
            time += gTime.Ellapsed;
            //TODO: Abfrage für Animation laden/starten wenn im Ziel bzw. am Start
            //TODO: Animation vervollständigen
            //TODO: Abfrage, wenn Player beschleunigt!?
            //TODO: Abhängig von Sprung machen(bzw. Gravitation 0 & Richtungstaste abfangen)
            //TODO: Funktion für isMovingRight schreiben und das umdrehen durch den Geist beachten
            if (GravitationAbsolut != 0)
            {
                if (isMovingright)
                {
                    sprite.Texture = textjumprechts;
                    if (auswahl == "Tofu")
                    {
                        x = new int[] { 4, 52, 104, 153 }; //X-Koordinaten von denen ausgeschnitten werden
                        y = new int[] { 0, 0, 0, 0 }; //Y-Koordinaten von denen ausgeschnitten werden soll
                        w = new int[] { 48, 48, 48, 48 }; //Länge der Bilder
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
                        w = new int[] { 41, 39, 74 };
                        h = new int[] { 61, 61, 61 };
                        animtime = 300;
                        animrepeat = true;
                    }
                }
                else
                {
                    if (isMovingleft)
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
                            x = new int[] { 111, 72, 0 };
                            y = new int[] { 0, 0, 0 };
                            w = new int[] { 41, 39, 72 };
                            h = new int[] { 61, 61, 61 };
                            animtime = 300;
                            animrepeat = true;
                        }
                    }
                    else // isIdle
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
                            x = new int[] { 0, 0, 0 };
                            y = new int[] { 0, 0, 0 };
                            w = new int[] { 72, 72, 72 };
                            h = new int[] { 61, 61, 61 };
                            animtime = 300;
                            animrepeat = true;
                        }
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

            if (checkneueanim(sprite.TextureRect,x,y,w,h))
                sprite.TextureRect = new IntRect(x[0], y[0], w[0], h[0]);
            else
            if (time.Milliseconds >= animtime)
                {
                    time = new TimeSpan(0);
                while (sprite.TextureRect.Left != x[i])
                    {
                        ++i;
                    }
                if (i == x.Length - 1 && animrepeat)
                {
                    i = 0;
                    sprite.TextureRect = new IntRect(x[i], y[i], w[i], h[i]);
                }
                else
                {
                    if(i != x.Length - 1)
                        ++i;
                    sprite.TextureRect = new IntRect(x[i], y[i], w[i], h[i]);
                }
            }
            // Console.Write("Animationtime: " + time.Milliseconds + "; \t");
            sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);
        }

        public void deadanim(GameTime  gtime)
        {

            if (deadtime.TotalMilliseconds > 1700)
                sprite.TextureRect = new IntRect(0, 0, 68, 64);
            else if (deadtime.TotalMilliseconds > 1400)
                sprite.TextureRect = new IntRect(68, 0, 68, 64);
            else if (deadtime.TotalMilliseconds > 1100)
                sprite.TextureRect = new IntRect(132, 0, 68, 64);
            else
                sprite.TextureRect = new IntRect(202, 0, 68, 64);
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

        public void resetpos()
        {
            deadtime = new TimeSpan(0, 0, 2);
            startpos = Map.getLastCheckpoint(Map01.checkPointList).getPositionVector2f();
            a = false;
            sprite.Texture = textdead;
            sprite.TextureRect = new IntRect(0,0,68,64);
            sterblich = false;
            Map01.pH.SpawnCollParticles(100,Position);
            //Console.WriteLine("start.x: " + startpos.X + "; start.y: " + startpos.Y);
        }

        void Sprung(GameTime gTime) 
        {
            //TODO: Optimieren mit gTime
            if (jump)
            {
                //GravitationAbsolut = baseGravitationAbsolut;
                //GravitationAbsolut = -1f;
                maxheight = sprite.Position.Y - jumpingHeight;
                //Console.WriteLine(maxheight);
                GravitationAbsolut = maxheight/300 ;
                Console.WriteLine(maxheight);
                jump = false;
                isJumping = true;
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

            if(!Map01.map.IsWalkable(this))
            {
                MovingDirection = new Vector2f(0, 0);
            }
            Vector2f check = MovingDirection * -1;
            if(!(MovingDirection.Equals(new Vector2f(0,0)) || check.Equals(new Vector2f(0,0))) && GravitationAbsolut == 0) //Partikel werden nur erstellt wenn er den Boden berührt
            {
                Vector2f start = new Vector2f(sprite.Position.X,sprite.Position.Y + 15);
                Map01.pH.SpawnMoveParticles(500, 30, gTime, start, MovingDirection, 2);
            }
            
        }

        public override void Update(GameTime gTime)
        {
            Map01.hud.Update(score);
            Map01.hud.Update(Position);
            if (deadtime.Seconds < 0)
            {
                if(a == false)
                {
                    sprite.Position = startpos;
                    maxheight = sprite.Position.Y;
                    a = true;
                    sterblich = true;
                }
                GravitationSpeed = baseGravitationSpeed * gTime.Ellapsed.Milliseconds;
                MovementSpeed = baseMovementSpeed * gTime.Ellapsed.Milliseconds;
                KeyboardInput(gTime);
                if (Map01.map.IsWalkable(this))
                    Move();
                Gravitation(gTime);
            }
            else
            {
                deadtime = deadtime.Subtract(new TimeSpan(gTime.Ellapsed.Ticks));
            }
        }

        public void Gravitation(GameTime gTime)
        {
            //if(GravitationAbsolut <= 10f)
            //    GravitationAbsolut += GravitationSpeed;
            MovementSpeed =  GravitationAbsolut;
            float div = sprite.Position.Y - maxheight;
            div = (div + 1) / 30;
            if (div >= 10f)
                div = 10f;
            if (GravitationAbsolut == 0)
                ++GravitationAbsolut;
            //Console.WriteLine(GravitationAbsolut);
            //Console.WriteLine(collmap());
            //Console.WriteLine("Position - maxheight: " + Math.Abs(div) + "\t Collision: " + collmap());
            if (isJumping)
            {
                korrektur = 2;
                sprite.Position -= new Vector2f(0, div) * gTime.Ellapsed.Milliseconds / 5;
            }
            else if(!isJumping && collmap())
            {
                sprite.Position += new Vector2f(0, div) * gTime.Ellapsed.Milliseconds / 5;
            }
            else
            {
                MovingDirection = new Vector2f(0, 0);
                jump = true;
                jumptrue = basejumptrue;
                GravitationAbsolut = 0f;
                maxheight = sprite.Position.Y - 50;
                isJumping = false;
            }
            MovingDirection = new Vector2f(0, div) * gTime.Ellapsed.Milliseconds / 5;
            if (Math.Abs(div) < 1f)
                isJumping = false;
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
            Map01.hud.setView(view);
        }
    }
}

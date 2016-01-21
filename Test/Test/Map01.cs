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
    class Map01 : GameState
    {
        public static Player player { get; private set; }
        public static Map map { get; private set; }
        public static Map collmap { get; private set; }
        public static Enemy01 enemy { get; private set; }
        public static Powerups01 powerups { get; private set; }
        static Sprite sprite;
        static Texture text;

        public void Draw(RenderWindow window)
        {
            player.setview(window);
            window.Draw(sprite);
            map.Draw(window);
            player.Draw(window);
            enemy.Draw(window);
            powerups.Draw(window);
        }

        public void Initialize()
        {
            //Objekte der Klassen werden initialisiert.
            map = new Map(new System.Drawing.Bitmap("Collision-Bitmap.bmp"));
            player = new Player("Cookie2", new Vector2f(200, 1400));
            enemy = new Enemy01();
            text = new Texture("Collision-Bitmap.bmp");
            sprite = new Sprite(text);
            sprite.Scale = new Vector2f(50, 50);
            powerups = new Powerups01();
            Stopwatch timer = new Stopwatch();
            TimeSpan time = new TimeSpan();
            timer.Start();
            time = new TimeSpan(0, 0, 1);

        }

        public void LoadContent()
        {

        }
    
    

        public EGameState Update(GameTime gTime)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                return EGameState.TitleScreen;

            gTime.Update();
            player.Update(gTime);
            Console.WriteLine("Player.X: " + Map01.player.Position.X + ";   Player.Y: " + Map01.player.Position.Y);
            if (player.a)
            {
                player.animation(gTime);
            }
            enemy.Update(gTime);
            powerups.Update(gTime);
            return EGameState.Map1;
        }
    }
}

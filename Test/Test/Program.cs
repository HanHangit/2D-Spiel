﻿using System;
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
    class Program
    {
        public static Player player { get; private set; }
        public static Map map { get; private set; }
        public static Map collmap { get; private set; }
        public static Enemy enemy { get; private set; }
        public static int anzahlgeist = 10;
        static GameTime gTime;


        public static void initialize()
        {           
            map = new Map(new System.Drawing.Bitmap("Collision-Map.bmp"));
            player = new Player("Tofu", new Vector2f(300, 300));
            enemy = new Enemy();
            gTime = new GameTime();
        }

        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(900, 900), "LoL");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };
            initialize();
            Stopwatch timer = new Stopwatch();
            TimeSpan time = new TimeSpan();
            timer.Start();
            time = new TimeSpan(0, 0, 1);
            while (window.IsOpen())
            {
                window.Clear(Color.Cyan);
                Update();
                Draw(window);
                window.DispatchEvents();

            }


        }
        static void Draw(RenderWindow window)
        {
            window.Clear(new Color(50, 120, 190));

            map.Draw(window);
            player.Draw(window);
            enemy.Draw(window);

            window.Display();
        }
        static void Update()
        {
            gTime.Update();
            player.Update(gTime);
            player.animation(gTime);
            enemy.Update(gTime);      
        }
    }
}

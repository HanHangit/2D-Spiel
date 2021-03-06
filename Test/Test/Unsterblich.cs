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
    class Unsterblich : GameObject
    {
        public Unsterblich(Vector2f position)
        {
            textlaufenrechts = new Texture("vitamin.png");
            sprite = new Sprite(textlaufenrechts);
            setposition(position);
            a = true;
            special = new TimeSpan(0);
        }

        public override void Update(GameTime gTime)
        {

            animation(gTime);
            if (special.Ticks == 0)
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
                if (sprite.TextureRect.Left > 50)
                    sprite.TextureRect = new IntRect( 7, 0, 66, 70);
                else
                    sprite.TextureRect = new IntRect(74, 0, 66, 70);
                sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);
            }
        }

        private void setposition(Vector2f position)
        {
            sprite.Position = position;
        }

        private void activate()
        {
            if (collplayer() && Map01.player.sterblich)
            { 
                a = false;
                    special = new TimeSpan(0, 0, 10);
                    Map01.player.sterblich = false;
                
            }
        }

        private void deactivate(GameTime gTime)
        {
            special = special.Subtract(new TimeSpan(gTime.Ellapsed.Ticks));
            //Console.WriteLine(special.Seconds);
            if (special.Ticks < 2)
            {
                special = new TimeSpan(0);
                Map01.player.sterblich = true;
            }
        }
    }
}

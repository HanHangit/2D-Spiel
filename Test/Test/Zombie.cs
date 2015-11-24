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
        public bool a;
        public Zombie(Vector2f pos)
        {
            textur = new Texture("zombie.png");
            sprite = new Sprite(textur);
            MovementSpeed = 0.4f;
            MovingDirection = new Vector2f(1, 0);
            sprite.TextureRect = new IntRect(0, 0, 39, 68);
            sprite.Origin = new Vector2f(sprite.TextureRect.Width / 2, sprite.TextureRect.Height / 2);
            setPosition(pos);
        }

        public override void Update(GameTime gTime)
        {
            animation(gTime);
            moving();
            if (a)
                activate();
            else
                deactivate(gTime);
        }

        public void animation(GameTime gTime)
        {
            time += gTime.Ellapsed;
            if (time.Milliseconds >= 300)
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
            while (Program.map.IsWalkablegrav(this))
            {
                sprite.Position += new Vector2f(0, 0.05f);
            }
        }

        private void moving()
        {

            if (Program.map.IsWalkablegrav(this))
            {
                MovingDirection *= -1;
            }
            Move();
        }


        private void activate()
        {

            float x = Program.player.Position.X - Program.player.sprite.TextureRect.Width;
            float y = Program.player.Position.Y - Program.player.sprite.TextureRect.Height;
            float sx = Program.player.Position.X + Program.player.sprite.TextureRect.Width;
            float sy = Program.player.Position.Y + Program.player.sprite.TextureRect.Height;

            if (x < Position.X && Position.X < sx && y < Position.Y && Position.Y < sy)
            {
                a = false;
                special = new TimeSpan(0, 0, 5);
                Program.player.baseMovementSpeed /= 2;
                sprite.Color = new Color(sprite.Color.R, sprite.Color.G, sprite.Color.B, 50);
            }
        }

        private void deactivate(GameTime gTime)
        {
            special = special.Subtract(new TimeSpan(gTime.Ellapsed.Ticks));
            Console.WriteLine(special.Ticks);
            if (special.Ticks < 2)
            {
                a = true;
                special = new TimeSpan(0);
                Program.player.baseMovementSpeed *= 2;
                sprite.Color = new Color(sprite.Color.R, sprite.Color.G, sprite.Color.B, 100);
            }
        }
    }
}

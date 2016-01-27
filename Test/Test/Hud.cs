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
    class Hud
    {
        private View view;
        private String time;
        private String leben;
        private String score;
        private String position;
        private Font font;
        private Text text;

        public Hud()
        {
            font = new Font("arial.ttf");
            text = new Text("", font);
            view = new View(new Vector2f(100, 100), new Vector2f(50, 50));
        }

        public void setView(View view)
        {
            this.view = view;
        }

        public void Update(TimeSpan total)
        {
            total = total.Subtract(Map01.start);
            if (total.Ticks < 0)
                total = total.Negate();
            time = total.Minutes + ":" + total.Seconds.ToString("00.") + ":" + total.Milliseconds; 
        }

        public void Update(Vector2f pos)
        {
            position = "X: " + (int)pos.X + "\n" + "Y: " + (int)pos.Y;
        }

        public void Update(int scr)
        {
            score = "" + scr;
        }

        public void Draw(RenderWindow win)
        {
            int k = 10;
            text = new Text(time, font);
            text.Color = new Color(Color.Red);
            text.Position = new Vector2f(view.Center.X - view.Size.X / 2 + k, view.Center.Y - view.Size.Y / 2 + k);
            win.Draw(text);

            text = new Text(score, font);
            text.Color = new Color(Color.Red);
            text.Position = new Vector2f(view.Center.X, view.Center.Y - view.Size.Y / 2 + k);
            win.Draw(text);

            text = new Text(position, font);

            text.Color = new Color(Color.Red);
            text.Position = new Vector2f(view.Center.X + view.Size.X / 2 - k - text.GetLocalBounds().Width , view.Center.Y - view.Size.Y / 2 + k);
            win.Draw(text);
           // Console.WriteLine(text.Position.ToString());
        }
    }
}

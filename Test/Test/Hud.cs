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
            text.Font = font;
        }
        public void setView(View view)
        {
            this.view = view;
        }
        public void Update(GameTime gTime)
        {
            time = gTime.Total.Minutes + ":" + gTime.Total.Seconds + ":" + gTime.Total.Milliseconds; 
        }
        public void Update(Vector2f pos)
        {
            position = "X: " + pos.X + "/r /n" + "Y: " + pos.Y;
        }
        public void Update(int scr)
        {
            score = "" + scr;
        }
        public void Draw(Window win)
        {
            
        }
    }
}

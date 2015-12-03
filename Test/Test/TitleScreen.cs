using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Test
{
    class TitleScreen : GameState
    {
        Sprite Background;
        

        public void Draw(RenderWindow win)
        {
            win.SetView(win.DefaultView);
            win.Draw(Background);
        }

        public void Initialize()
        {
            
            Background = new Sprite(new Texture("Burger.png"));
        }

        public void LoadContent()
        {

        }

        public EGameState Update(GameTime t)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                return EGameState.Map1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                return EGameState.Map2;
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                return EGameState.Map3;

            return EGameState.TitleScreen;
        }
    }
}

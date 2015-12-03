using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Test
{
    class Game
    {
        RenderWindow window;
        EGameState prev = EGameState.None, curr = EGameState.TitleScreen;
        GameState state;
        GameTime gTime;

        public Game()
        {
            window = new RenderWindow(new VideoMode(800, 600), "LoL");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };
            window.SetFramerateLimit(120);
            gTime = new GameTime();
        }

        public void Run()
        {
            while (window.IsOpen())
            {
                Update();
                Draw();
                window.DispatchEvents();
            }
        }

        void HandleGameState()
        {
            switch (curr)
            {
                case EGameState.None:
                    window.Close();
                    break;
                case EGameState.TitleScreen:
                    state = new TitleScreen();
                    state.LoadContent();
                    state.Initialize();
                    break;
                case EGameState.Map1:
                    state = new Map01();
                    state.LoadContent();
                    state.Initialize();
                    break;
                default:
                    break;
            }
        }

        void Update()
        {
            if (prev != curr)
            {
                HandleGameState();
                prev = curr;
            }

            curr = state.Update(gTime);
        }

        void Draw()
        {
            window.Clear(new Color(50, 120, 190));

            state.Draw(window);

            window.Display();
        }
    }
}

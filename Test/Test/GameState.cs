using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Test
{
    enum EGameState
    {
        None = -1,

        TitleScreen,
        MainMenu,
        Map1,
        Map2,
        Map3,
        Credits,

        Count
    }

    interface GameState
    {
        void Initialize();

        void LoadContent();

        void Draw(RenderWindow win);


        EGameState Update(GameTime t);
    }
}

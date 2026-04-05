using Jokenpo.View.Game;
using Jokenpo.View.Menus;
using Jokenpo.View.TableRender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jokenpo.Controller
{
    public class GameController
    {
        public static void APP()
        {
            MenuPrincipal.MenuScreen();
            while (true)
            {
                GameScreen.GamePlay();
                int restart = GameScreen.RestartMessage();

                if (restart != 1) break;
            }
            
        }
    }
}

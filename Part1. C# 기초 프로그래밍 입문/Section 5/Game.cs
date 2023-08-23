using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    class Game
    {
        private Lobby lobby;
        private BattleField battleField;
        private Town town;
        private Player player;

        public Game()
        {
            lobby = new Lobby();
            battleField = new BattleField();    
            town = new Town();

            player = lobby.ProcessField();
            player.ShowInfo();
        }
        public void StartGame()
        {
            town.EnterField();
            town.ProcessField();
            battleField.EnterField();
            while (player.GetAlive())
            {
                battleField.ProcessField(player);
            }
        }
    }
}

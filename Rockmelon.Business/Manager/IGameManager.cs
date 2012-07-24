using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rockmelon.Domain;

namespace Rockmelon.Business
{
    public interface IGameManager
    {
        void SaveGame(Game game);
        IEnumerable<Game> ListGames(GameCriteria criteria);
        Game GetGame(int gameId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rockmelon.Helpers;

namespace Rockmelon.Site.Game.Models
{
    public class GameModel
    {
        public GameModel()
        {
            Games = new GridItems<Rockmelon.Domain.Game>();
        }

        public GridItems<Rockmelon.Domain.Game> Games;
    }
}
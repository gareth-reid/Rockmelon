using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rockmelon.Site.Game.Models
{
    public class GameModel
    {
        public GameModel()
        {
            Games = new List<Domain.Game>();
        }
        public IEnumerable<Rockmelon.Domain.Game> Games { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rockmelon.Domain;

namespace Rockmelon.Business
{
    public class GameEngine : IGameEngine
    {
        public void BuildRating(Game game)
        {
            game.Ratings.Add(new Rating()
            {
                RatingValue = game.RatingValue, 
                GameId = game.GameId, 
                Game = game
            });
        }
    }
}

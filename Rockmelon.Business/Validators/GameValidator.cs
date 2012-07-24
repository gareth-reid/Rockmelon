using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Rockmelon.Domain;

namespace Rockmelon.Business
{
    public class GameValidator : IGameValidator
    {
        public void Validate(Game game)
        {
            //could but this into an engine
            if(game.Ratings != null && game.Ratings.First().RatingId > 5)
            {
                throw new DataException("Rating can not be greater then 5");
            }
            if(String.IsNullOrEmpty(game.Title))
            {
                throw new DataException("Title required");
            }
        }
      
    }
}

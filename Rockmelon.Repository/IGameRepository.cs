using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Rockmelon.Domain;

namespace Rockmelon.Repository
{
    public interface IGameRepository 
    {
        void Save(Game game);
        Game Get(int id);
        IEnumerable<Game> List(IEnumerable<Func<Game, object>> criteria);
    }
}
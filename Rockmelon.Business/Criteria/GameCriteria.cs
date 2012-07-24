using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rockmelon.Domain;

namespace Rockmelon.Business
{
    public class GameCriteria : IGameCriteria
    {
        public IEnumerable<Func<Game, object>> BuildCriteria(IGameCriteria criteria)
        {
            return new List<Func<Game, object>>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rockmelon.Domain;

namespace Rockmelon.Business
{
    public interface IGameEngine
    {
        void BuildRating(Game game);
    }
}

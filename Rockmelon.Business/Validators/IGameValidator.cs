using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Rockmelon.Domain;

namespace Rockmelon.Business
{
    public interface IGameValidator
    {
        void Validate(Game game);
    }
}

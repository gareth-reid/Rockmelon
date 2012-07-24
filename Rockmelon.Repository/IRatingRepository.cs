using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Rockmelon.Domain;

namespace Rockmelon.Repository
{
    public interface IRatingRepository 
    {
        void Save(Rating game);
    }
}
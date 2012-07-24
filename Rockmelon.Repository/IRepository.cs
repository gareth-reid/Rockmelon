using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Rockmelon.Repository
{    
    public interface IRepository<TEntity>
    {
        void Save(TEntity entity, Func<TEntity, int> key);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> List();
    }
}
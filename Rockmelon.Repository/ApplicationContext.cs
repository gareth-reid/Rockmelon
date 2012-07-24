using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;

namespace Rockmelon.Repository
{
    public class ApplicationContext : DbContext, IDbContext
    {
        public ApplicationContext()
        {
            Database.SetInitializer<DbContext>(null);
            //Database.Connection.ConnectionString = "data source=.;Integrated Security=SSPI;Initial Catalog=RM";
            Database.Connection.Open();   
        }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    } 
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Data.Entity;

namespace Rockmelon.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        public Repository()
        {
            var context = new ApplicationContext();
            var testDataBaseInitializer = new DataBaseInitializer();
            testDataBaseInitializer.InitializeDatabase(context);
            _context = context;
        }
        private IDbSet<TEntity> DbSet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }        

        public void Save(TEntity entity, Func<TEntity, int> key)
        {
            DbSet.Attach(entity);
            if (key.Invoke(entity) > 0)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _context.Entry(entity).State = EntityState.Added;
            }

            _context.SaveChanges();
        }
        
        public List<TEntity> List(int id)
        {
            var baseQuery = DbSet;
            IQueryable<TEntity> query = (DbQuery<TEntity>)baseQuery;
            return query.ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            var baseQuery = DbSet;
            return baseQuery;
        }

        public IEnumerable<TEntity> List()
        {
            var baseQuery = DbSet;
            return baseQuery;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

    }
}
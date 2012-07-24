using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Rockmelon.Domain;

namespace Rockmelon.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private IRepository<Rating> _Repository;
        public RatingRepository(IRepository<Rating> repository)
        {
            _Repository = repository;
        }
        public void Save(Rating rating)
        {
            _Repository.Save(rating, r => r.RatingId);                
        }
    }
}
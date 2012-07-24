using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Rockmelon.Domain;

namespace Rockmelon.Repository
{
    public class GameRepository : IGameRepository
    {
        private IRepository<Game> _Repository;
        public GameRepository(IRepository<Game> repository)
        {
            _Repository = repository;
        }
        public void Save(Game game)
        {
            _Repository.Save(game, g => g.GameId);                
        }

        public Game Get(int id)
        {
            return _Repository.GetAll().First(g => g.GameId == id);    
        }

        public IEnumerable<Game> List(IEnumerable<Func<Game, object>> criteria)
        {
            //apply criteria here using linq
            return _Repository.List();
        }
    }
}
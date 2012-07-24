using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Ninject;
using Rockmelon.Domain;
using Rockmelon.Repository;

namespace Rockmelon.Business
{
    public class GameManager : IGameManager
    {
        private readonly IGameRepository _GameRepository;
        private readonly IRatingRepository _RatingRepository;
        private readonly IGameValidator _GameValidator;
        private readonly IGameCriteria _GameCriteria;
        private readonly IGameEngine _GameEngine;

        [Inject]
        public GameManager(IGameRepository gameRepository, IGameValidator gameValidator, IGameCriteria gameCriteria, IGameEngine gameEngine, IRatingRepository ratingRepository)
        {
            _GameRepository = gameRepository;// Ioc.Container.Get<IGameRepository>();
            _GameValidator = gameValidator;
            _GameCriteria = gameCriteria;
            _GameEngine = gameEngine;
            _RatingRepository = ratingRepository;
        }

        public void SaveGame(Game game)
        {
            _GameEngine.BuildRating(game);
            _GameValidator.Validate(game);
            //TODO: cascade properly
            foreach (var rating in game.Ratings)
            {
                _RatingRepository.Save(rating);    
            }
            
            _GameRepository.Save(game);
        }

        public IEnumerable<Game> ListGames(GameCriteria criteria)
        {
            return _GameRepository.List(_GameCriteria.BuildCriteria(criteria));
        }

        public Game GetGame(int gameId)
        {
            return _GameRepository.Get(gameId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rockmelon.Business;
using Rockmelon.Domain;
using Rockmelon.Helpers;
using Rockmelon.Site.Game.Models;

namespace Rockmelon.Site.Game.Controllers
{
    public class GameController : Controller
    {
        //didnt have enough time to do controller contructor injection (did in business layer) -would of liked to
        private IGameManager _GameManager;
        public GameController()
        {
            _GameManager = Ioc.Container.Get<IGameManager>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return PartialView(BuildModel());
        }

        public ActionResult Detail(int? gameId)
        {
            return PartialView(_GameManager.GetGame(gameId ?? 0));
        }

        public ActionResult Save(Rockmelon.Domain.Game game)
        {
            _GameManager.SaveGame(game);
            return RedirectToAction("");
        }

        public GameModel BuildModel()
        {
            var model = new GameModel();
            var games = _GameManager.ListGames(new GameCriteria());
            model.Games = ToList(games);
            return model;
        }

        public GridItems<Rockmelon.Domain.Game> ToList(IEnumerable<Rockmelon.Domain.Game> games)
        {
            var grid = new GridItems<Rockmelon.Domain.Game>();
            grid.PrimaryKey = new Func<Rockmelon.Domain.Game, int>(g => g.GameId);
            grid.Columns = new List<Func<Rockmelon.Domain.Game, object>>()
                               {
                                   new Func<Rockmelon.Domain.Game, object>(g => g.Title),
                                   new Func<Rockmelon.Domain.Game, object>(g => g.Description),
                                   new Func<Rockmelon.Domain.Game, object>(g => g.TotalRating())
                               };
            foreach (var game in games)
            {
                grid.Items.Add(game);
            }
            return grid;
        }
    }
}

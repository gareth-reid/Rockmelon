using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rockmelon.Business;
using Rockmelon.Domain;
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
            model.Games = _GameManager.ListGames(new GameCriteria());
            return model;
        }
    }
}

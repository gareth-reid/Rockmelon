using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Rockmelon.Domain;
using NUnit.Framework;


namespace Rockmelon.Repository
{
    [TestFixture]
    public class GameRepositoryTests : BaseUnitTest
    {
        private const string _title = "Gears of War 3";
        private const string _description = "Desc";
        [Test]
        public void Game_Save()
        {
            base.Init();
            var gRepo = Ioc.Container.Get<IGameRepository>();
            var g = new Game()
            {
                Title = _title,
                Description = ""
            };
            gRepo.Save(g);
            Assert.IsTrue(g.GameId > 0);
        }

        [Test]
        public void Game_ChangeDescription_Save()
        {
            base.Init();
            var gRepo = Ioc.Container.Get<IGameRepository>();
            var g = new Game()
            {
                Title = _title,
                Description = _description
            };
            gRepo.Save(g);
            var g2 = gRepo.Get(g.GameId);
            g2.Description = "NewDesc";
            gRepo.Save(g2);
            Assert.AreNotEqual(_description, g2.Description);
        }

        [Test]
        public void Game_ChangeRating_Save()
        {
            base.Init();
            var gRepo = Ioc.Container.Get<IGameRepository>();
            var g = new Game()
            {
                Title = _title,
                Description = "",
            };
            
            gRepo.Save(g);
            g.Ratings.Add(new Rating() { RatingValue = 3, GameId = g.GameId});
            gRepo.Save(g);

            var g2 = gRepo.Get(g.GameId);
            gRepo.Save(g2);
            g2.Ratings.Add(new Rating() { RatingValue = 5, GameId = g2.GameId});
            gRepo.Save(g2);
            Assert.AreEqual(2, g2.Ratings.Count());
            Assert.AreEqual(3, g2.Ratings.First().RatingValue);
            Assert.AreEqual(5, g2.Ratings.ToList()[1].RatingValue);
        }

        [Test]
        public void Game_Get()
        {
            base.Init();
            var gRepo = Ioc.Container.Get<IGameRepository>();
            var g = new Game()
            {
                Title = _title,
                Description = ""
            };
            gRepo.Save(g);
            var reload = gRepo.Get(g.GameId);
            Assert.IsNotNull(reload);
            Assert.AreEqual(_title, reload.Title);

        }
    }
}

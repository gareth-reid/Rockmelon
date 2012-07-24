using System.Collections.Generic;
using Rockmelon.Domain;
using Rockmelon.Repository;
using Moq;
using NUnit.Framework;

namespace Rockmelon.Business.Tests
{
    [TestFixture]
    public class GameTests : BaseUnitTest
    {
        [Test]
        public void Game_Save()
        {
            base.Init();
            var r = new Mock<IRepository<Game>>();
            r.Setup(o => o.GetAll()).Returns(new List<Game>() { new Game() { GameId = 1, Description = "Gears of War 3" } });
            Ioc.Container.Register<IRepository<Game>>(r.Object);
            
            var person = new Game()
            {
                Description = "Gareth"
            };
            var personRepo = new GameRepository(r.Object);
            var result = personRepo.Get(1);           
        }

        [Test]
        public void Game_UpdateRating_Success()
        {
            base.Init();
            var g = new Game()
            {
                Description = "desc",
                GameId = 1,
                Title = "Title"
            };
            g.Ratings.Add(BuildRating(1));
            g.Ratings.Add(BuildRating(2));
            g.Ratings.Add(BuildRating(3));
            g.Ratings.Add(BuildRating(4));
            g.Ratings.Add(BuildRating(5));
            var total = g.TotalRating();
            //15 / 5 = 3
            Assert.AreEqual(total, 3);
        }

        [Test]
        public void Game_UpdateRating_ReturnZero()
        {
            base.Init();
            var g = new Game()
            {
                Description = "desc",
                GameId = 1,
                Title = "Title"
            };
            //no ratings
            var total = g.TotalRating();
            Assert.AreEqual(total, 0);
        }

        private Rating BuildRating(int val)
        {
            return new Rating()
            {
                RatingValue = val
            };
        }
    }
}

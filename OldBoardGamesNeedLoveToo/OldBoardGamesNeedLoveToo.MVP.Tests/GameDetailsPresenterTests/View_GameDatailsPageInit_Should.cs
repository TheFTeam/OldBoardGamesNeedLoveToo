using System;
using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.GameDetailsPresenterTests
{
    [TestFixture]
    public class View_GameDatailsPageInit_Should
    {
        [Test]
        public void AddUsersToViewModel_WhenOnGetDataEventIsRaised()
        {
            //Arrange
            var viewMock = new Mock<IGameDetailsView>();
            viewMock.Setup(v => v.Model).Returns(new GamesViewModel());
            var gamesServiceMock = new Mock<IGamesService>();
            var gameId = Guid.NewGuid();

            var exprecteGameCollection = new List<Game>()
            {
                new Game()
                {
                    Id = gameId,
                    Name = "Awesome Game 3",
                    Condition = ConditionType.VeryGood
                }
            };
            gamesServiceMock.Setup(x => x.GetAllGames()).Returns(exprecteGameCollection);
            var expectedGame = exprecteGameCollection.Where(g => g.Id == gameId);

            GameDetailsPresenter gameDetailsPresenter = new GameDetailsPresenter(viewMock.Object, gamesServiceMock.Object);

            //Act
            viewMock.Raise(v => v.GameDatailsPageInit += null, null, new GameDetailsEventArgs(gameId));

            // Assert
            Assert.AreEqual(expectedGame, viewMock.Object.Model.Games);
        }
    }
}
using System;
using System.Web.ModelBinding;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.AminGamesPresenterTests
{
    [TestFixture]
    public class View_AdminUpdateGames_Should
    {
        [Test]
        public void AddModelError_WhenItemIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<IAdminGamesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            Guid gameId = Guid.NewGuid();
            string errorKey = string.Empty;
            string expectedError = string.Format("Item with id {0} was not found", gameId);
            var gamesServiceMock = new Mock<IGamesService>();
            gamesServiceMock.Setup(c => c.GetGameById(gameId)).Returns<Game>(null);

            AdminGamesPresenter adminGamesPresenter = new AdminGamesPresenter(viewMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminUpdateGames += null, null, new GameDetailsEventArgs(gameId));

            // Assert
            Assert.AreEqual(1, viewMock.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        [Test]
        public void TryUpdateModelIsNotCalled_WhenItemIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<IAdminGamesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            var gamesServiceMock = new Mock<IGamesService>();
            Guid gameId = Guid.NewGuid();
            gamesServiceMock.Setup(c => c.GetGameById(gameId)).Returns<UserCustomInfo>(null);

            AdminGamesPresenter adminGamePresenter = new AdminGamesPresenter(viewMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminUpdateGames += null, null, new GameDetailsEventArgs(gameId));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Game>()), Times.Never());
        }

        [Test]
        public void TryUpdateModelIsCalled_WhenItemIsFound()
        {
            // Arrange
            var viewMock = new Mock<IAdminGamesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            Guid gameId = Guid.NewGuid();
            var gamesServiceMock = new Mock<IGamesService>();
            gamesServiceMock.Setup(c => c.GetGameById(gameId)).Returns(new Game() { Id = gameId });

            AdminGamesPresenter adminGamesPresenter = new AdminGamesPresenter(viewMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminUpdateGames += null, null, new GameDetailsEventArgs(gameId));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Game>()), Times.Once());
        }

        [Test]
        public void UpdateGameIsCalled_WhenItemIsFoundAndIsInValidState()
        {
            // Arrange
            var viewMock = new Mock<IAdminGamesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            Guid gameId = Guid.NewGuid();
            var gamesServiceMock = new Mock<IGamesService>();
            var game = new Game() { Id = gameId };
            gamesServiceMock.Setup(c => c.GetGameById(gameId)).Returns(game);

            AdminGamesPresenter adminGamesPresenter = new AdminGamesPresenter(viewMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminUpdateGames += null, null, new GameDetailsEventArgs(gameId));

            // Assert
            gamesServiceMock.Verify(c => c.UpdateGame(game), Times.Once());
        }

        [Test]
        public void UpdateGameIsNotCalled_WhenItemIsFoundAndIsInInValidState()
        {
            // Arrange
            var viewMock = new Mock<IAdminGamesView>();
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("game", "game is not in valid state");
            viewMock.Setup(v => v.ModelState).Returns(modelState);

            Guid gameId = Guid.NewGuid();
            var gamesServiceMock = new Mock<IGamesService>();
            var game = new Game() { Id = gameId };
            gamesServiceMock.Setup(c => c.GetGameById(gameId)).Returns(game);

            AdminGamesPresenter adminGamesPresenter = new AdminGamesPresenter(viewMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminUpdateGames += null, null, new GameDetailsEventArgs(gameId));

            // Assert
            gamesServiceMock.Verify(c => c.UpdateGame(game), Times.Never());
        }
    }
}
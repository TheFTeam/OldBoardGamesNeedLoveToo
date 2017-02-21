using Moq;
using NUnit.Framework;
using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Models;
using System;
using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.GamesListUserControlPresenterTests
{
    [TestFixture]
    public class View_OnButtonFilterSubmit_Should
    {
        [Test]
        public void Throw_WhenMinPriceIsNotInTheCorrectFormat()
        {
            var viewMock = new Mock<IGamesView>();

            var gamesServiceMock = new Mock<IGamesService>();

            var categoryServiceMock = new Mock<ICategoriesService>();

            GamesListUserControlPresenter gamesListUserControlPresenter = new GamesListUserControlPresenter(viewMock.Object, gamesServiceMock.Object, categoryServiceMock.Object);

            var filterGamesEventArgs = new FilterGamesEventArgs();
            filterGamesEventArgs.MinPrice = "notDecimalValue";
            filterGamesEventArgs.MaxPrice = "10";
            filterGamesEventArgs.MinNumberOfPlayers = "1";
            filterGamesEventArgs.MaxNumberOfPlayers = "2";
            filterGamesEventArgs.MinPlayersAge = "2";
            filterGamesEventArgs.MaxPlayersAge = "20";
            filterGamesEventArgs.Condition = "Excellent";
            filterGamesEventArgs.ReleasedateFrom = "10/10/2015";
            filterGamesEventArgs.ReleaseDateTo = "10/10/2015";
            filterGamesEventArgs.CategoryId = "1da7a9e3-8b02-43c7-8a5b-13ca318ce4d5";
            
            // Act & Assert
            Assert.That(() => viewMock.Raise(v => v.OnButtonFilterSubmit += null, filterGamesEventArgs),
            Throws.InvalidOperationException.With.Message.Contains("not in a correct format"));
        }

        [Test]
        public void Throw_WhenMaxPriceIsNotInTheCorrectFormat()
        {
            var viewMock = new Mock<IGamesView>();

            var gamesServiceMock = new Mock<IGamesService>();

            var categoryServiceMock = new Mock<ICategoriesService>();

            GamesListUserControlPresenter gamesListUserControlPresenter = new GamesListUserControlPresenter(viewMock.Object, gamesServiceMock.Object, categoryServiceMock.Object);

            var filterGamesEventArgs = new FilterGamesEventArgs();
            filterGamesEventArgs.MinPrice = "10";
            filterGamesEventArgs.MaxPrice = "notDecimalValue";
            filterGamesEventArgs.MinNumberOfPlayers = "1";
            filterGamesEventArgs.MaxNumberOfPlayers = "2";
            filterGamesEventArgs.MinPlayersAge = "2";
            filterGamesEventArgs.MaxPlayersAge = "20";
            filterGamesEventArgs.Condition = "Excellent";
            filterGamesEventArgs.ReleasedateFrom = "10/10/2015";
            filterGamesEventArgs.ReleaseDateTo = "10/10/2015";
            filterGamesEventArgs.CategoryId = "1da7a9e3-8b02-43c7-8a5b-13ca318ce4d5";

            // Act & Assert
            Assert.That(() => viewMock.Raise(v => v.OnButtonFilterSubmit += null, filterGamesEventArgs),
            Throws.InvalidOperationException.With.Message.Contains("not in a correct format"));
        }

        [Test]
        public void Throw_WhenMinNumberOfPlayersIsNotInTheCorrectFormat()
        {
            var viewMock = new Mock<IGamesView>();

            var gamesServiceMock = new Mock<IGamesService>();

            var categoryServiceMock = new Mock<ICategoriesService>();

            GamesListUserControlPresenter gamesListUserControlPresenter = new GamesListUserControlPresenter(viewMock.Object, gamesServiceMock.Object, categoryServiceMock.Object);

            var filterGamesEventArgs = new FilterGamesEventArgs();
            filterGamesEventArgs.MinPrice = "10";
            filterGamesEventArgs.MaxPrice = "20";
            filterGamesEventArgs.MinNumberOfPlayers = "notInt";
            filterGamesEventArgs.MaxNumberOfPlayers = "2";
            filterGamesEventArgs.MinPlayersAge = "2";
            filterGamesEventArgs.MaxPlayersAge = "20";
            filterGamesEventArgs.Condition = "Excellent";
            filterGamesEventArgs.ReleasedateFrom = "10/10/2015";
            filterGamesEventArgs.ReleaseDateTo = "10/10/2015";
            filterGamesEventArgs.CategoryId = "1da7a9e3-8b02-43c7-8a5b-13ca318ce4d5";

            // Act & Assert
            Assert.That(() => viewMock.Raise(v => v.OnButtonFilterSubmit += null, filterGamesEventArgs),
            Throws.InvalidOperationException.With.Message.Contains("not in a correct format"));
        }
        [Test]
        public void Throw_WhenMaxNumberOfPlayersIsNotInTheCorrectFormat()
        {
            var viewMock = new Mock<IGamesView>();

            var gamesServiceMock = new Mock<IGamesService>();

            var categoryServiceMock = new Mock<ICategoriesService>();

            GamesListUserControlPresenter gamesListUserControlPresenter = new GamesListUserControlPresenter(viewMock.Object, gamesServiceMock.Object, categoryServiceMock.Object);

            var filterGamesEventArgs = new FilterGamesEventArgs();
            filterGamesEventArgs.MinPrice = "10";
            filterGamesEventArgs.MaxPrice = "20";
            filterGamesEventArgs.MinNumberOfPlayers = "1";
            filterGamesEventArgs.MaxNumberOfPlayers = "notInt";
            filterGamesEventArgs.MinPlayersAge = "2";
            filterGamesEventArgs.MaxPlayersAge = "20";
            filterGamesEventArgs.Condition = "Excellent";
            filterGamesEventArgs.ReleasedateFrom = "10/10/2015";
            filterGamesEventArgs.ReleaseDateTo = "10/10/2015";
            filterGamesEventArgs.CategoryId = "1da7a9e3-8b02-43c7-8a5b-13ca318ce4d5";

            // Act & Assert
            Assert.That(() => viewMock.Raise(v => v.OnButtonFilterSubmit += null, filterGamesEventArgs),
            Throws.InvalidOperationException.With.Message.Contains("not in a correct format"));
        }

        [Test]
        public void Throw_WhenMinPlayersAgeIsNotInTheCorrectFormat()
        {
            var viewMock = new Mock<IGamesView>();

            var gamesServiceMock = new Mock<IGamesService>();

            var categoryServiceMock = new Mock<ICategoriesService>();

            GamesListUserControlPresenter gamesListUserControlPresenter = new GamesListUserControlPresenter(viewMock.Object, gamesServiceMock.Object, categoryServiceMock.Object);

            var filterGamesEventArgs = new FilterGamesEventArgs();
            filterGamesEventArgs.MinPrice = "10";
            filterGamesEventArgs.MaxPrice = "20";
            filterGamesEventArgs.MinNumberOfPlayers = "1";
            filterGamesEventArgs.MaxNumberOfPlayers = "4";
            filterGamesEventArgs.MinPlayersAge = "notInt";
            filterGamesEventArgs.MaxPlayersAge = "20";
            filterGamesEventArgs.Condition = "Excellent";
            filterGamesEventArgs.ReleasedateFrom = "10/10/2015";
            filterGamesEventArgs.ReleaseDateTo = "10/10/2015";
            filterGamesEventArgs.CategoryId = "1da7a9e3-8b02-43c7-8a5b-13ca318ce4d5";

            // Act & Assert
            Assert.That(() => viewMock.Raise(v => v.OnButtonFilterSubmit += null, filterGamesEventArgs),
            Throws.InvalidOperationException.With.Message.Contains("not in a correct format"));
        }

        [Test]
        public void Throw_WhenMaxPlayersAgeIsNotInTheCorrectFormat()
        {
            var viewMock = new Mock<IGamesView>();

            var gamesServiceMock = new Mock<IGamesService>();

            var categoryServiceMock = new Mock<ICategoriesService>();

            GamesListUserControlPresenter gamesListUserControlPresenter = new GamesListUserControlPresenter(viewMock.Object, gamesServiceMock.Object, categoryServiceMock.Object);

            var filterGamesEventArgs = new FilterGamesEventArgs();
            filterGamesEventArgs.MinPrice = "10";
            filterGamesEventArgs.MaxPrice = "20";
            filterGamesEventArgs.MinNumberOfPlayers = "1";
            filterGamesEventArgs.MaxNumberOfPlayers = "4";
            filterGamesEventArgs.MinPlayersAge = "10";
            filterGamesEventArgs.MaxPlayersAge = "notInt";
            filterGamesEventArgs.Condition = "Excellent";
            filterGamesEventArgs.ReleasedateFrom = "10/10/2015";
            filterGamesEventArgs.ReleaseDateTo = "10/10/2015";
            filterGamesEventArgs.CategoryId = "1da7a9e3-8b02-43c7-8a5b-13ca318ce4d5";

            // Act & Assert
            Assert.That(() => viewMock.Raise(v => v.OnButtonFilterSubmit += null, filterGamesEventArgs),
            Throws.InvalidOperationException.With.Message.Contains("not in a correct format"));
        }

        [Test]
        public void Throw_WhenConditionIsNotInTheCorrectFormat()
        {
            var viewMock = new Mock<IGamesView>();

            var gamesServiceMock = new Mock<IGamesService>();

            var categoryServiceMock = new Mock<ICategoriesService>();

            GamesListUserControlPresenter gamesListUserControlPresenter = new GamesListUserControlPresenter(viewMock.Object, gamesServiceMock.Object, categoryServiceMock.Object);

            var filterGamesEventArgs = new FilterGamesEventArgs();
            filterGamesEventArgs.MinPrice = "10";
            filterGamesEventArgs.MaxPrice = "20";
            filterGamesEventArgs.MinNumberOfPlayers = "1";
            filterGamesEventArgs.MaxNumberOfPlayers = "4";
            filterGamesEventArgs.MinPlayersAge = "10";
            filterGamesEventArgs.MaxPlayersAge = "20";
            filterGamesEventArgs.Condition = "notCorrectCondition";
            filterGamesEventArgs.ReleasedateFrom = "10/10/2015";
            filterGamesEventArgs.ReleaseDateTo = "10/10/2015";
            filterGamesEventArgs.CategoryId = "1da7a9e3-8b02-43c7-8a5b-13ca318ce4d5";

            // Act & Assert
            Assert.That(() => viewMock.Raise(v => v.OnButtonFilterSubmit += null, filterGamesEventArgs),
            Throws.InvalidOperationException.With.Message.Contains(filterGamesEventArgs.Condition));
        }

        [Test]
        public void Throw_WhenReleasedateFromIsNotInTheCorrectFormat()
        {
            var viewMock = new Mock<IGamesView>();

            var gamesServiceMock = new Mock<IGamesService>();

            var categoryServiceMock = new Mock<ICategoriesService>();

            GamesListUserControlPresenter gamesListUserControlPresenter = new GamesListUserControlPresenter(viewMock.Object, gamesServiceMock.Object, categoryServiceMock.Object);

            var filterGamesEventArgs = new FilterGamesEventArgs();
            filterGamesEventArgs.MinPrice = "10";
            filterGamesEventArgs.MaxPrice = "20";
            filterGamesEventArgs.MinNumberOfPlayers = "1";
            filterGamesEventArgs.MaxNumberOfPlayers = "4";
            filterGamesEventArgs.MinPlayersAge = "10";
            filterGamesEventArgs.MaxPlayersAge = "20";
            filterGamesEventArgs.Condition = "Excellent";
            filterGamesEventArgs.ReleasedateFrom = "notCorrectDate";
            filterGamesEventArgs.ReleaseDateTo = "10/10/2015";
            filterGamesEventArgs.CategoryId = "1da7a9e3-8b02-43c7-8a5b-13ca318ce4d5";

            // Act & Assert
            Assert.That(() => viewMock.Raise(v => v.OnButtonFilterSubmit += null, filterGamesEventArgs),
            Throws.InvalidOperationException.With.Message.Contains("string was not recognized"));
        }
        [Test]
        public void Throw_WhenReleaseDateToIsNotInTheCorrectFormat()
        {
            var viewMock = new Mock<IGamesView>();

            var gamesServiceMock = new Mock<IGamesService>();

            var categoryServiceMock = new Mock<ICategoriesService>();

            GamesListUserControlPresenter gamesListUserControlPresenter = new GamesListUserControlPresenter(viewMock.Object, gamesServiceMock.Object, categoryServiceMock.Object);

            var filterGamesEventArgs = new FilterGamesEventArgs();
            filterGamesEventArgs.MinPrice = "10";
            filterGamesEventArgs.MaxPrice = "20";
            filterGamesEventArgs.MinNumberOfPlayers = "1";
            filterGamesEventArgs.MaxNumberOfPlayers = "4";
            filterGamesEventArgs.MinPlayersAge = "10";
            filterGamesEventArgs.MaxPlayersAge = "20";
            filterGamesEventArgs.Condition = "Excellent";
            filterGamesEventArgs.ReleasedateFrom = "10/10/2015";
            filterGamesEventArgs.ReleaseDateTo = "notCorrectDateFormat";
            filterGamesEventArgs.CategoryId = "1da7a9e3-8b02-43c7-8a5b-13ca318ce4d5";

            // Act & Assert
            Assert.That(() => viewMock.Raise(v => v.OnButtonFilterSubmit += null, filterGamesEventArgs),
            Throws.InvalidOperationException.With.Message.Contains("string was not recognized"));
        }

        [Test]
        public void Throw_WhenCategoryIdIsNotInTheCorrectFormat()
        {
            var viewMock = new Mock<IGamesView>();

            var gamesServiceMock = new Mock<IGamesService>();

            var categoryServiceMock = new Mock<ICategoriesService>();

            GamesListUserControlPresenter gamesListUserControlPresenter = new GamesListUserControlPresenter(viewMock.Object, gamesServiceMock.Object, categoryServiceMock.Object);

            var filterGamesEventArgs = new FilterGamesEventArgs();
            filterGamesEventArgs.MinPrice = "10";
            filterGamesEventArgs.MaxPrice = "20";
            filterGamesEventArgs.MinNumberOfPlayers = "1";
            filterGamesEventArgs.MaxNumberOfPlayers = "4";
            filterGamesEventArgs.MinPlayersAge = "10";
            filterGamesEventArgs.MaxPlayersAge = "20";
            filterGamesEventArgs.Condition = "Excellent";
            filterGamesEventArgs.ReleasedateFrom = "10/10/2015";
            filterGamesEventArgs.ReleaseDateTo = "10/10/2015";
            filterGamesEventArgs.CategoryId = "notCorrectGuid";

            // Act & Assert
            Assert.That(() => viewMock.Raise(v => v.OnButtonFilterSubmit += null, filterGamesEventArgs),
            Throws.InvalidOperationException.With.Message.Contains("Guid should contain 32"));
        }

        [Test]
        public void AddCategoriesToViewModel_WhenEventIsRaisdAndParametersAreValid()
        {
            var viewMock = new Mock<IGamesView>();
            viewMock.Setup(v => v.Model).Returns(new GamesViewModel());

            IEnumerable<Game> games = new List<Game>()
            {
                new Game() {Name="game1" },
                new Game() {Name="game2" },
                new Game() {Name="game3" }
            };
            var gamesServiceMock = new Mock<IGamesService>();
            var expectedGames= gamesServiceMock.Setup(
                g => g.GetAllFilteredGames(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Guid>(), It.IsAny<ConditionType>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(games);

            var categoryServiceMock = new Mock<ICategoriesService>();

            GamesListUserControlPresenter gamesListUserControlPresenter = new GamesListUserControlPresenter(viewMock.Object, gamesServiceMock.Object, categoryServiceMock.Object);

            var filterGamesEventArgs = new FilterGamesEventArgs();
            filterGamesEventArgs.MinPrice = "10";
            filterGamesEventArgs.MaxPrice = "20";
            filterGamesEventArgs.MinNumberOfPlayers = "1";
            filterGamesEventArgs.MaxNumberOfPlayers = "4";
            filterGamesEventArgs.MinPlayersAge = "10";
            filterGamesEventArgs.MaxPlayersAge = "20";
            filterGamesEventArgs.Condition = "Excellent";
            filterGamesEventArgs.ReleasedateFrom = "10/10/2015";
            filterGamesEventArgs.ReleaseDateTo = "10/10/2015";
            filterGamesEventArgs.CategoryId = "1da7a9e3-8b02-43c7-8a5b-13ca318ce4d5";

            viewMock.Raise(v => v.OnButtonFilterSubmit += null, filterGamesEventArgs);

            // Act & Assert
            CollectionAssert.AreEquivalent(games, viewMock.Object.Model.Games);
        }

    }
}

using Moq;
using NUnit.Framework;
using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Models;
using System;
using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.GamesListUserControlPresenterTests
{
    [TestFixture]
    public class View_DefaultPageInit_Should
    {
        [Test]
        public void AddCategoriesToViewModel_WhenDefaultPageInitEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<IGamesView>();
            viewMock.Setup(v => v.Model).Returns(new GamesViewModel());

            var categories = new List<Category>()
                {
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Friends"
                    },
                     new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Indoors"
                    },
                      new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Family"
                    }
                };

            var gamesServiceMock = new Mock<IGamesService>();

            var categoryServiceMock = new Mock<ICategoriesService>();
            categoryServiceMock.Setup(c => c.GetAllCategories()).Returns(categories);

            GamesListUserControlPresenter gamesListUserControlPresenter = new GamesListUserControlPresenter(viewMock.Object, gamesServiceMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.DefaultPageInit += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(categories, viewMock.Object.Model.Categories);
        }
    }
}

using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.AddGamePresenterTests
{
    [TestFixture]
    public class View_OnPageInit_Should
    {
        [TestFixture]
        public class View_OnCategoriesGetData_Should
        {
            [Test]
            public void AddCategoriesToViewModel_WhenOnPageInitEventIsRaised()
            {
                // Arrange
                var viewMock = new Mock<IAddGameView>();
                viewMock.Setup(v => v.Model).Returns(new AddGameViewModel());

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
                categoryServiceMock.Setup(c => c.GetAllCategories())
                    .Returns(categories);

                AddGamePresenter addGamePresenter = new AddGamePresenter(viewMock.Object, gamesServiceMock.Object, categoryServiceMock.Object);

                // Act
                viewMock.Raise(v => v.OnPageInit += null, EventArgs.Empty);

                // Assert
                CollectionAssert.AreEquivalent(categories, viewMock.Object.Model.Categories);
            }
        }
    }
}
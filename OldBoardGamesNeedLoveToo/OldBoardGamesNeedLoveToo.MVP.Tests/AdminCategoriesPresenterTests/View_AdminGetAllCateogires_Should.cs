using Moq;
using NUnit.Framework;
using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Models;
using System;
using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.AdminCategoriesPresenterTests
{
    [TestFixture]
    public class View_AdminGetAllCateogires_Should
    {
        [Test]
        public void AddCategoriesToViewModel_WhenOnPageInitEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<IAdminCategoriesView>();
            viewMock.Setup(v => v.Model).Returns(new AdminCategoriesViewModel());

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

            var categoryServiceMock = new Mock<ICategoriesService>();
            categoryServiceMock.Setup(c => c.GetAllCategories()).Returns(categories);

            AdminCategoriesPresenter adminCategoriesPresenter = new AdminCategoriesPresenter(viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminGetAllCateogires += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(categories, viewMock.Object.Model.Categories);
        }
    }
}
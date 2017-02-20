using System;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.AdminCategoriesPresenterTests
{
    [TestFixture]
    public class View_AdminAddCategory_Should
    {
        [Test]
        public void InvokeCreateCategory_WhenEventAdminAddcategoryIsRaisedAndEventArgsAreValid()
        {
            //Arrange
            var viewMock = new Mock<IAdminCategoriesView>();
            var categoriesServiceMock = new Mock<ICategoriesService>();

            var categoryName = "newCategory";
            var category = new Category() { Id = Guid.NewGuid(), Name = categoryName };
            categoriesServiceMock.Setup(c => c.CreateCategory(categoryName)).Returns(category);

            AdminCategoriesPresenter adminCategoriesPresenter = new AdminCategoriesPresenter(viewMock.Object, categoriesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminAddCategory += null, new NewCategoryEventArgs(categoryName));

            // Assert
            categoriesServiceMock.Verify(c => c.CreateCategory(categoryName), Times.Once());
        }

        [Test]
        public void InvokeAddCategory_WhenEventAdminAddcategoryIsRaisedAndEventArgsAreValid()
        {
            //Arrange
            var viewMock = new Mock<IAdminCategoriesView>();
            var categoriesServiceMock = new Mock<ICategoriesService>();

            var categoryName = "newCategory";
            var category = new Category() { Id = Guid.NewGuid(), Name = categoryName };
            categoriesServiceMock.Setup(c => c.CreateCategory(categoryName)).Returns(category);

            AdminCategoriesPresenter adminCategoriesPresenter = new AdminCategoriesPresenter(viewMock.Object, categoriesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminAddCategory += null, new NewCategoryEventArgs(categoryName));

            // Assert
            categoriesServiceMock.Verify(c => c.AddCategory(category), Times.Once());
        }
    }
}
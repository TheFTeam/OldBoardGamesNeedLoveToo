using System;
using System.Web.ModelBinding;

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
    public class View_AdminDeteleCategory_Should
    {
        [Test]
        public void AddModelError_WhenItemIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<IAdminCategoriesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            Guid categoryId = Guid.NewGuid();
            string expectedError = string.Format("Item with id {0} was not found", categoryId);
            var categoryServiceMock = new Mock<ICategoriesService>();
            categoryServiceMock.Setup(c => c.GetCategoryById(categoryId)).Returns<Category>(null);

            AdminCategoriesPresenter adminCategoriesPresenter = new AdminCategoriesPresenter(viewMock.Object, categoryServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminDeteleCategory += null, new CategoryEventArgs(categoryId));

            // Assert
            Assert.AreEqual(1, viewMock.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        [Test]
        public void DeleteCategoryIsCalled_WhenItemIsFound()
        {
            // Arrange
            var viewMock = new Mock<IAdminCategoriesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            Guid categoryId = Guid.NewGuid();
            var categoriesServiceMock = new Mock<ICategoriesService>();
            var category = new Category() { Id = categoryId };
            categoriesServiceMock.Setup(c => c.GetCategoryById(categoryId)).Returns(category);

            AdminCategoriesPresenter adminCategoriesPresenter = new AdminCategoriesPresenter(viewMock.Object, categoriesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminDeteleCategory += null, new CategoryEventArgs(categoryId));

            // Assert
            categoriesServiceMock.Verify(c => c.DeleteCategory(category), Times.Once());
        }
    }
}
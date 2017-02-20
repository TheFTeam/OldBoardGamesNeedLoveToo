using System;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Tests.CategoriesServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnNull_WhenIdParameterIsNull()
        {
            //Arrange
            var categoriesRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            CategoriesService categoriesService = new CategoriesService(categoriesRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            Category categoryResult = categoriesService.GetCategoryById(null);

            //Assert
            Assert.IsNull(categoryResult);
        }

        [Test]
        public void ReturnCategory_WhenIdIsValid()
        {
            //Arrange
            var categoriesRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Guid categoryId = Guid.NewGuid();
            Category category = new Category() { Id = categoryId, Name = "Cards" };

            categoriesRepositoryMock.Setup(c => c.GetById(categoryId)).Returns(category);

            CategoriesService categoriesService = new CategoriesService(categoriesRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            Category categoryResult = categoriesService.GetCategoryById(categoryId);

            //Assert
            Assert.AreSame(category, categoryResult);
        }
    }
}
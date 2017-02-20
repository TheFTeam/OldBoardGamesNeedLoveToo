using System;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Tests.CategoriesServiceTests
{
    [TestFixture]
    public class UpdateCategory_Should
    {
        [Test]
        public void Throw_WhenThePassedCategoryIsNull()
        {
            //Arrange
            var categoriesRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            CategoriesService categoriesService = new CategoriesService(categoriesRepositoryMock.Object, unitOfWorkMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => categoriesService.UpdateCategory(null));
        }

        [Test]
        public void InvokeRepositoryMethodUpdateOnce_WhenThePassedCategoryIsValid()
        {
            //Arrange
            var categoriesRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            CategoriesService categoriesService = new CategoriesService(categoriesRepositoryMock.Object, unitOfWorkMock.Object);
            Guid categoryId = Guid.NewGuid();
            Category category = new Category() { Id = categoryId, Name = "Cards" };

            //Act
            categoriesService.UpdateCategory(category);

            //Assert
            categoriesRepositoryMock.Verify(x => x.Update(It.IsAny<Category>()), Times.Once);
        }
    }
}
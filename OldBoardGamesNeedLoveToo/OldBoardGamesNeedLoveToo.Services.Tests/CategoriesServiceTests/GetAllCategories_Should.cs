using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Tests.CategoriesServiceTests
{
    [TestFixture]
    public class GetAllCategories_Should
    {
        [Test]
        public void Invoke_TheRepositoryMethodGetAll_Once()
        {
            //Arrange
            var categoriesRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            CategoriesService categoriesService = new CategoriesService(categoriesRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            IEnumerable<Category> categoryResult = categoriesService.GetAllCategories();

            //Assert
            categoriesRepositoryMock.Verify(c => c.GetAll(), Times.Once);
        }

        [Test]
        public void ReturnResult_WhenInvokingRepositoryMethod_GetAll()
        {
            //Arrange
            var categoriesRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            IEnumerable<Category> expectedResultCollection = new List<Category>();

            categoriesRepositoryMock.Setup(c => c.GetAll()).Returns(() =>
            {
                return expectedResultCollection;
            });

            CategoriesService categoriesService = new CategoriesService(categoriesRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            IEnumerable<Category> categoryResult = categoriesService.GetAllCategories();

            //Assert
            Assert.That(categoryResult, Is.EqualTo(expectedResultCollection));
        }

        [Test]
        public void ReturnResultOfCorrectType()
        {
            //Arrange
            var categoriesRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            categoriesRepositoryMock.Setup(c => c.GetAll()).Returns(() =>
            {
                IEnumerable<Category> expectedResultCollection = new List<Category>();
                return expectedResultCollection;
            });

            CategoriesService categoriesService = new CategoriesService(categoriesRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            IEnumerable<Category> categoryResult = categoriesService.GetAllCategories();

            //Assert
            Assert.That(categoryResult, Is.InstanceOf<IEnumerable<Category>>());
        }

        [Test]
        public void ReturnNull_WhenReposityMethodGetAll_ReturnsNull()
        {
            //Arrange
            var categoriesRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            categoriesRepositoryMock.Setup(c => c.GetAll()).Returns(() =>
            {
                return null;
            });

            CategoriesService categoriesService = new CategoriesService(categoriesRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            IEnumerable<Category> categoryResult = categoriesService.GetAllCategories();

            //Assert
            Assert.IsNull(categoryResult);
        }
    }
}
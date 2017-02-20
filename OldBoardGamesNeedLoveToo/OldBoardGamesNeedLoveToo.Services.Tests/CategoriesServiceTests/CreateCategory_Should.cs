using Moq;
using NUnit.Framework;
using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBoardGamesNeedLoveToo.Services.Tests.CategoriesServiceTests
{
    [TestFixture]
    public class CreateCategory_Should
    {
        [Test]
        public void Throw_WhenPassedParameterIsNull()
        {
            //Arrange
            var categoriesRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            CategoriesService categoriesService = new CategoriesService(categoriesRepositoryMock.Object, unitOfWorkMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => categoriesService.CreateCategory(null));
        }

        [Test]
        public void ReturnCategory_WhenPassedParameterIsValid()
        {
            //Arrange
            var categoriesRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Guid categoryId = Guid.NewGuid();
            string name = "Cards";
            Category categoryExpected = new Category() { Name = name };

            CategoriesService categoriesService = new CategoriesService(categoriesRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            Category categoryResult = categoriesService.CreateCategory(name);

            //Assert
            Assert.AreEqual(categoryExpected.Name, categoryResult.Name);
        }
    }
}

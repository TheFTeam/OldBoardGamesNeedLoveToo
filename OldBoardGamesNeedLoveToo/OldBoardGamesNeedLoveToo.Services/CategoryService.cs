using System;
using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly string categoriesRepositoryCannotBeNullExceptinMessage = "Categories repository can not be null";
        private readonly string unitOfWorkCannotBeNullExceptinMessage = "UnitfWork can not be null";

        private readonly IRepository<Category> categoriesRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IRepository<Category> categoriesRepository, IUnitOfWork unitOfWork)
        {
            if (categoriesRepository == null)
            {
                throw new ArgumentException(categoriesRepositoryCannotBeNullExceptinMessage);
            }

            this.categoriesRepository = categoriesRepository;

            if (unitOfWork == null)
            {
                throw new ArgumentException(unitOfWorkCannotBeNullExceptinMessage);
            }

            this.unitOfWork = unitOfWork;
        }

        public void AddCategory(Category category)
        {
            this.categoriesRepository.Add(category);
            this.unitOfWork.Commit();
        }

        public Category CreateCategory(string name)
        {
            return new Category()
            {
                Name = name
            };
        }

        public void Deletecategory(Category category)
        {
            this.categoriesRepository.Delete(category);
            this.unitOfWork.Commit();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return this.categoriesRepository.GetAll();
        }

        public Category GetCategoryById(object id)
        {
            return this.categoriesRepository.GetById(id);
        }

        public void UpdateCategory(Category category)
        {
            this.categoriesRepository.Update(category);
            this.unitOfWork.Commit();
        }
    }
}
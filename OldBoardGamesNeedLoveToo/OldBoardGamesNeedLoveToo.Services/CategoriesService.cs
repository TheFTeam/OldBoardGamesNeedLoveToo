using System.Collections.Generic;

using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoriesService(IRepository<Category> categoriesRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(categoriesRepository, "categoriesRepository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.categoriesRepository = categoriesRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddCategory(Category category)
        {
            Guard.WhenArgument(category, "category").IsNull().Throw();

            this.categoriesRepository.Add(category);
            this.unitOfWork.Commit();
        }

        public Category CreateCategory(string name)
        {
            Guard.WhenArgument(name, "name").IsNull().Throw();

            return new Category()
            {
                Name = name
            };
        }

        public void DeleteCategory(Category category)
        {
            Guard.WhenArgument(category, "category").IsNull().Throw();

            this.categoriesRepository.Delete(category);
            this.unitOfWork.Commit();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return this.categoriesRepository.GetAll();
        }

        public Category GetCategoryById(object id)
        {
            Guard.WhenArgument(id, "id").IsNull().Throw();

            return this.categoriesRepository.GetById(id);
        }

        public void UpdateCategory(Category category)
        {
            Guard.WhenArgument(category, "category").IsNull().Throw();

            this.categoriesRepository.Update(category);
            this.unitOfWork.Commit();
        }
    }
}
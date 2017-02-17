using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Contracts
{
    public interface ICategoriesService
    {
        Category GetCategoryById(object id);

        IEnumerable<Category> GetAllCategories();

        Category CreateCategory(string name);

        void AddCategory(Category category);

        void UpdateCategory(Category category);

        void Deletecategory(Category category);
    }
}

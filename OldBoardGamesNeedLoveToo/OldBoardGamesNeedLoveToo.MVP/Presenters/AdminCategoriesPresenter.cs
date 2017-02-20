using System;

using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class AdminCategoriesPresenter : Presenter<IAdminCategoriesView>
    {
        private readonly ICategoriesService categoriesService;
        public AdminCategoriesPresenter(IAdminCategoriesView view, ICategoriesService categoriesService) : base(view)
        {
            Guard.WhenArgument(categoriesService, "categoriesService").IsNull().Throw();

            this.categoriesService = categoriesService;

            this.View.AdminGetAllCateogires += this.View_AdminGetAllCateogires;
            this.View.AdminDeteleCategory += this.View_AdminDeteleCategory;
            this.View.AdminAddCategory += this.View_AdminAddCategory;
            this.View.AdminChangeCategory += this.View_AdminChangeCategory;
        }

        private void View_AdminChangeCategory(object sender, CategoryEventArgs e)
        {
            Category categoryToBeChanged = this.categoriesService.GetCategoryById(e.Id);
            if (categoryToBeChanged == null)
            {
                this.View.ModelState.AddModelError("", string.Format("Item with id {0} was not found", e.Id));
                return;
            }
            this.View.TryUpdateModel(categoryToBeChanged);
            if (this.View.ModelState.IsValid)
            {
                this.categoriesService.UpdateCategory(categoryToBeChanged);
            }
        }

        private void View_AdminAddCategory(object sender, NewCategoryEventArgs e)
        {
            Category categoryToBeAdded = this.categoriesService.CreateCategory(e.CategoryName);
            this.categoriesService.AddCategory(categoryToBeAdded);
        }

        private void View_AdminDeteleCategory(object sender, CategoryEventArgs e)
        {
            Category categoryToBeDeleted = this.categoriesService.GetCategoryById(e.Id);
            if (categoryToBeDeleted == null)
            {
                this.View.ModelState.AddModelError("", string.Format("Item with id {0} was not found", e.Id));
                return;
            }
            this.categoriesService.DeleteCategory(categoryToBeDeleted);
        }

        private void View_AdminGetAllCateogires(object sender, EventArgs e)
        {
            this.View.Model.Categories = this.categoriesService.GetAllCategories();
        }
    }
}

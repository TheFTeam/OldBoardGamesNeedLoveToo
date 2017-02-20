using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class AdminCategoriesPresenter : Presenter<IAdminCategoriesView>
    {
        private readonly string viewCannotBeNullExceptionMessage = "View can not be null.";
        private readonly string categoriesServiceCannotBeNullExceptionMessage = "Games service can not be null.";

        private readonly ICategoriesService categoriesService;
        public AdminCategoriesPresenter(IAdminCategoriesView view, ICategoriesService categoriesService) : base(view)
        {
            if (view == null)
            {
                throw new ArgumentException(viewCannotBeNullExceptionMessage);
            }
            if (categoriesService == null)
            {
                throw new ArgumentException(categoriesServiceCannotBeNullExceptionMessage);
            }

            this.categoriesService = categoriesService;

            this.View.AdmingetAllCateogires += View_AdmingetAllCateogires;
            this.View.AdminDeteleCategory += View_AdminDeteleCategory;
            this.View.AdminAddCategory += View_AdminAddCategory;
            this.View.AdminChangeCategory += View_AdminChangeCategory;
        }

        private void View_AdminChangeCategory(object sender, CategoryEventArgs e)
        {
            Category categoryToBeChanged = this.categoriesService.GetCategoryById(e.Id);
            if (categoryToBeChanged == null)
            {
                this.View.ModelState.AddModelError("", String.Format("Item with id {0} was not found", e.Id));
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
            if (categoryToBeDeleted==null)
            {
                this.View.ModelState.AddModelError("", string.Format("Item with id {0} was not found", e.Id));
                return;
            }
            this.categoriesService.DeleteCategory(categoryToBeDeleted);
        }

        private void View_AdmingetAllCateogires(object sender, EventArgs e)
        {
            this.View.Model.Categories = this.categoriesService.GetAllCategories();
        }
    }
}

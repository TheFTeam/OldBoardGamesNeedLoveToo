using System;
using System.Web.ModelBinding;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IAdminCategoriesView : IView<AdminCategoriesViewModel>
    {
        event EventHandler AdminGetAllCateogires;
        event EventHandler<NewCategoryEventArgs> AdminAddCategory;
        event EventHandler<CategoryEventArgs> AdminDeteleCategory;
        event EventHandler<CategoryEventArgs> AdminChangeCategory;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}

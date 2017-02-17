using System;
using System.Web.ModelBinding;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IAccountInfoView : IView<UsersViewModel>
    {
        event EventHandler<UserDetailsByIdEventArgs> OnGetData;

        event EventHandler<UserDetailsByIdEventArgs> OnUpdateItem;
                
        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;
using System;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IAdminUsersView : IView<AdminUsersViewModel>
    {
        event EventHandler AdminGetAllUsers;
        event EventHandler<GameDetailsEventArgs> AdminUpdateUser;
        event EventHandler<GameDetailsEventArgs> AdminDeleteUser;
        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}

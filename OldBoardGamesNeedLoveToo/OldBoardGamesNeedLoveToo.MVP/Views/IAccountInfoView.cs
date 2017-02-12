using System;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IAccountInfoView : IView<UsersViewModel>
    {
        event EventHandler<UserDetailsEventArgs> DefaultPageInit;

        event EventHandler<ObjectDataSourceUserDetailsEventArgs> ObjectCreating;
    }
}
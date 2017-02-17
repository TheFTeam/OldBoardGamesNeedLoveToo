using System;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IUserProfileView : IView<UsersViewModel>
    {
        event EventHandler<UserDetailsByUsernameEventArgs> OnUserProfilePageInit;
    }
}
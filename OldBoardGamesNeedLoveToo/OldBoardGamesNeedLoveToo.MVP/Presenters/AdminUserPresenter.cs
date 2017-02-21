using System;

using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class AdminUserPresenter : Presenter<IAdminUsersView>
    {
        private readonly IUsersService usersService;
        public AdminUserPresenter(IAdminUsersView view, IUsersService usersService) : base(view)
        {
            Guard.WhenArgument(usersService, "usersService").IsNull().Throw();

            this.usersService = usersService;

            this.View.AdminGetAllUsers += this.View_AdminGetAllUsers;
            this.View.AdminUpdateUser += this.View_AdminUpdateUser;
            this.View.AdminDeleteUser += this.View_AdminDeleteUser;
        }

        private void View_AdminDeleteUser(object sender, UserDetailsByIdEventArgs e)
        {
            UserCustomInfo userToBeDeleted = this.usersService.GetUserCustomInfoById(e.Id);

            if (userToBeDeleted == null)
            {
                this.View.ModelState.AddModelError("", string.Format("Item with id {0} was not found", e.Id));
                return;
            }

            this.usersService.DeleteUserCustomInfo(userToBeDeleted);
        }

        private void View_AdminUpdateUser(object sender, UserDetailsByIdEventArgs e)
        {
            UserCustomInfo userToBeUpdated = this.usersService.GetUserCustomInfoById(e.Id);
            if (userToBeUpdated == null)
            {
                this.View.ModelState.AddModelError("", string.Format("Item with id {0} was not found", e.Id));
                return;
            }
            this.View.TryUpdateModel(userToBeUpdated);
            if (this.View.ModelState.IsValid)
            {
                this.usersService.UpdateUserCustomInfo(userToBeUpdated);
            }
        }

        private void View_AdminGetAllUsers(object sender, EventArgs e)
        {
            this.View.Model.Users = this.usersService.GetAllUserCustomInfos();
        }
    }
}
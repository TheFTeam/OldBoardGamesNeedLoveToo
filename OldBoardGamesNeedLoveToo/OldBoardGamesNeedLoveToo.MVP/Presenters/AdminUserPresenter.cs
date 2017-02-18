using OldBoardGamesNeedLoveToo.Models;
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
    public class AdminUserPresenter : Presenter<IAdminUsersView>
    {
        private readonly string viewCannotBeNullExceptionMessage = "View can not be null.";
        private readonly string usersServiceCannotBeNullExceptionMessage = "User service can not be null.";

        private readonly IUsersService usersService;
        public AdminUserPresenter(IAdminUsersView view, IUsersService usersService) : base(view)
        {
            if (view == null)
            {
                throw new ArgumentException(viewCannotBeNullExceptionMessage);
            }
            if (usersService == null)
            {
                throw new ArgumentException(usersServiceCannotBeNullExceptionMessage);
            }

            this.usersService = usersService;

            this.View.AdminGetAllUsers += View_AdminGetAllUsers;
            this.View.AdminUpdateUser += View_AdminUpdateUser;
            this.View.AdminDeleteUser += View_AdminDeleteUser;
        }

        private void View_AdminDeleteUser(object sender, CustomEventArgs.GameDetailsEventArgs e)
        {
            UserCustomInfo userToBeDeleted = this.usersService.GetUserCustomInfoById(e.Id);

            if (userToBeDeleted == null)
            {
                this.View.ModelState.AddModelError("", string.Format("Item with id {0} was not found", e.Id));
                return;
            }

            this.usersService.DeleteUserCustomInfo(userToBeDeleted);
        }

        private void View_AdminUpdateUser(object sender, CustomEventArgs.GameDetailsEventArgs e)
        {
            UserCustomInfo userToBeUpdated = this.usersService.GetUserCustomInfoById(e.Id);
            if (userToBeUpdated == null)
            {
                this.View.ModelState.AddModelError("", String.Format("Item with id {0} was not found", e.Id));
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

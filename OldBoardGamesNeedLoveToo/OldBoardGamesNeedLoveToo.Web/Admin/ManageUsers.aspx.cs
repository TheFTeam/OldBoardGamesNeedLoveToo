using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;

namespace OldBoardGamesNeedLoveToo.Web.Admin
{
    [PresenterBinding(typeof(AdminUserPresenter))]
    public partial class ManageUsers : MvpPage<AdminUsersViewModel>, IAdminUsersView
    {
        public event EventHandler AdminGetAllUsers;
        public event EventHandler<UserDetailsByIdEventArgs> AdminUpdateUser;
        public event EventHandler<UserDetailsByIdEventArgs> AdminDeleteUser;

        public IQueryable<UserCustomInfo> GridViewManageUsers_GetData()
        {
            this.AdminGetAllUsers?.Invoke(this, null);
            return this.Model.Users.ToList().AsQueryable();
        }

        public void GridViewManageUsers_UpdateItem(Guid id)
        {
            this.AdminUpdateUser?.Invoke(this, new UserDetailsByIdEventArgs(id));
        }

        public void GridViewManageUsers_DeleteItem(Guid id)
        {
            this.AdminDeleteUser?.Invoke(this, new UserDetailsByIdEventArgs(id));
        }
    }
}
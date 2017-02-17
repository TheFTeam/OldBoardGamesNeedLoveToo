using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using System.Linq;

namespace OldBoardGamesNeedLoveToo.Web
{
    [PresenterBinding(typeof(UserProfilePresenter))]
    public partial class UserProfile : MvpPage<UsersViewModel>, IUserProfileView
    {
        public event EventHandler<UserDetailsByUsernameEventArgs> OnUserProfilePageInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = this.GetUsernameFromQueryString();
            this.OnUserProfilePageInit?.Invoke(sender, new UserDetailsByUsernameEventArgs(username));
            this.FormViewUserProfile.DataSource = this.Model.Users;
            this.UserProfileGamesList.DataSource = this.Model.Games.ToList();
            this.UserProfileGamesList.DataBind();
        }

        public string GetUsernameFromQueryString()
        {
            return this.Request.QueryString["username"];
        }
    }
}
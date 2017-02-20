using System;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using WebFormsMvp;
using WebFormsMvp.Web;

using OldBoardGamesNeedLoveToo.Auth;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;

namespace OldBoardGamesNeedLoveToo.Web
{
    [PresenterBinding(typeof(UserProfilePresenter))]
    public partial class UserProfile : MvpPage<UsersViewModel>, IUserProfileView
    {
        public event EventHandler<UserDetailsByUsernameEventArgs> OnUserProfilePageInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CheckIfUserIsLoggedToSetRatingVisibility();

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

        public void CheckIfUserIsLoggedToSetRatingVisibility()
        {
            ApplicationUser user = HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(HttpContext.Current.User.Identity.GetUserId());

            if (user != null)
            {
                this.UserControlRating.IsVisible = true;
            }
            else
            {
                this.UserControlRating.IsVisible = false;
                this.UserControlRating.ReadOnly = true;
            }
        }
    }
}
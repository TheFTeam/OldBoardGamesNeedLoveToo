using System;
using System.Web;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using WebFormsMvp;
using WebFormsMvp.Web;

using Ninject;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Web.Models;
using OldBoardGamesNeedLoveToo.Web.App_Start;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.Web
{
    [PresenterBinding(typeof(AccountInfoPresenter))]
    public partial class AccountInfo : MvpPage<UsersViewModel>, IAccountInfoView
    {
        public event EventHandler<UserDetailsEventArgs> DefaultPageInit;
        public event EventHandler<ObjectDataSourceUserDetailsEventArgs> ObjectCreating;

        protected void Page_Load(object sender, EventArgs e)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            if (user != null)
            {
                var id = user.UserCustomInfo.Id;
                this.Session["Id"] = id;
                this.Session.Timeout = 30;
            }            

            //this.DefaultPageInit?.Invoke(sender, new UserDetailsEventArgs(id));

            //if (!IsPostBack)
            //{
            //    this.ListViewUserDetails.DataSource = this.Model.Users;
            //    this.ListViewUserDetails.DataBind();
            //}
        }

        protected void ObjectDataSourceUserDetails_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            var service = NinjectWebCommon.Kernel.Get<IUserService>();
            this.ObjectCreating?.Invoke(sender, new ObjectDataSourceUserDetailsEventArgs(service));
            e.ObjectInstance = service;
            this.ListViewUserDetails.DataBind();
        }
    }
}
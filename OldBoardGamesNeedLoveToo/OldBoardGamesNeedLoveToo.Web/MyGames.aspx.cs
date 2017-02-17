using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ninject;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using OldBoardGamesNeedLoveToo.Web.App_Start;
using OldBoardGamesNeedLoveToo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;

namespace OldBoardGamesNeedLoveToo.Web
{
    [PresenterBinding(typeof(MyGamesPresenter))]
    public partial class MyGames : MvpPage<GamesViewModel>, IMyGamesView
    {
        public event EventHandler<MyGamesEventArgs> MyGamesPageInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var id = user.UserCustomInfo.Id;

            this.MyGamesPageInit?.Invoke(sender, new MyGamesEventArgs(id));

            if (!IsPostBack)
            {
                this.GridViewMyGames.DataSource = this.Model.Games;
                this.GridViewMyGames.DataBind();
            }
        }
    }
}
using System;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

using WebFormsMvp;
using WebFormsMvp.Web;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.Web.Models;

namespace OldBoardGamesNeedLoveToo.Web
{
    [PresenterBinding(typeof(GameDetailsPresenter))]
    public partial class GameDetails : MvpPage<GamesViewModel>, IGameDetailsView
    {
        public event EventHandler<GameDetailsEventArgs> GameDatailsPageInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            Guid id = new Guid(this.Request.QueryString["id"]);

            this.GameDatailsPageInit?.Invoke(sender, new GameDetailsEventArgs(id));

            if (!IsPostBack)
            {
                this.FormViewGameDetails.DataSource = this.Model.Games;
                this.DataBind();
            }

            this.CheckIfUserIsLoggedToSetCommentsVisibility();
        }

        public void CheckIfUserIsLoggedToSetCommentsVisibility()
        {
            ApplicationUser user = HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(HttpContext.Current.User.Identity.GetUserId());

            if (user != null)
            {
                this.UserControlCommentsList.IsVisible = true;
            }
            else
            {
                this.UserControlCommentsList.IsVisible = false;
            }
        }
    }
}
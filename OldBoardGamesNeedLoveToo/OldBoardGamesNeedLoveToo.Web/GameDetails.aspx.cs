using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.MVP.Presenters;

namespace OldBoardGamesNeedLoveToo.Web
{
    [PresenterBinding(typeof(GameDetailsPresenter))]
    public partial class GameDetails : MvpPage<GamesViewModel>, IGameDetailsView
    {
        public event EventHandler<GameDetailsEventArgs> GameDatailsPageInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(this.Request.QueryString["id"]);

            this.GameDatailsPageInit?.Invoke(sender, new GameDetailsEventArgs(id));

            if (!IsPostBack)
            {
                this.FormViewGameDetails.DataSource = this.Model.Games;
                this.FormViewGameDetails.DataBind();
            }
        }

    }
}
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using System;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace OldBoardGamesNeedLoveToo.Web.Admin
{
    [PresenterBinding(typeof(GamesPresenter))]
    public partial class ManageGames : MvpPage<GamesViewModel>, IGamesView
    {
        public event EventHandler DefaultPageInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DefaultPageInit?.Invoke(sender, e);

            if (!IsPostBack)
            {
                this.ListViewGames.DataSource = this.Model.Games;
                this.ListViewGames.DataBind();
            }
        }
    }
}
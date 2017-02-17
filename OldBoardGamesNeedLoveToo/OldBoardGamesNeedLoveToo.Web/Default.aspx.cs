using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using System.Linq;

namespace OldBoardGamesNeedLoveToo.Web
{
    [PresenterBinding(typeof(DefaultPagePresenter))]
    public partial class _Default : MvpPage<GamesViewModel>, IDefaultPageView
    {
        public event EventHandler DefaultPageInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DefaultPageInit?.Invoke(sender, e);
            if (!IsPostBack)
            {
                this.DefaultGamesList.DataSource = this.Model.Games.ToList();
                this.DefaultGamesList.DataBind();
            }
        }
    }
}
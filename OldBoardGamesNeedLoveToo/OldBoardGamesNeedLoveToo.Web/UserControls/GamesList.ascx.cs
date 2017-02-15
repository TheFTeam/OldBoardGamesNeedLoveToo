using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;

namespace OldBoardGamesNeedLoveToo.Web.UserControls
{
    [PresenterBinding(typeof(GamesPresenter))]
    public partial class GamesList : MvpUserControl<GamesViewModel>, IGamesView
    {
        public event EventHandler DefaultPageInit;
        public event EventHandler<FilterGamesEventArgs> OnButtonFilterSubmit;

        public object GamesDataSource
        {
            get
            {
                return this.ListViewGames.DataSource;
            }
            set
            {
                this.ListViewGames.DataSource = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DefaultPageInit?.Invoke(sender, e);

            if (!IsPostBack)
            {
                this.ListViewGames.DataSource = this.Model.Games;
                this.ListViewGames.DataBind();

                this.DropDownListCategories.DataSource = this.Model.Categories;
                this.DropDownListCategories.DataBind();
            }
        }

        protected void ButtonFilterSubmit_Click(object sender, EventArgs e)
        {
            var args = new FilterGamesEventArgs();
            args.CategoryId = this.DropDownListCategories.SelectedValue;
            args.MinPrice = this.TextBoxMinPrice.Text;
            args.MaxPrice = this.TextBoxMaxPrice.Text;
            args.MinNumberOfPlayers = this.TextBoxMinPlayers.Text;
            args.MaxNumberOfPlayers = this.TextBoxMaxPlayers.Text;
            args.MinPlayersAge = this.TextBoxMinAge.Text;
            args.MaxPlayersAge = this.TextBoxMaxAge.Text;
            args.Condition = this.DropDownListCondition.SelectedValue;
            args.ReleasedateFrom = this.TextBoxReleaseDateFrom.Text;
            args.ReleaseDateTo = this.TextBoxReleaseDateTo.Text;

            this.OnButtonFilterSubmit?.Invoke(sender, args);

            this.ListViewGames.DataSource = this.Model.Games;
            this.ListViewGames.DataBind();
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            this.DataBind();
        }
    }
}
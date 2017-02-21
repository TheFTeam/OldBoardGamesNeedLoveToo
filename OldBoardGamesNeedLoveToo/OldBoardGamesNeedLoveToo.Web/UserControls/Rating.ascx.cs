using System;

using WebFormsMvp.Web;
using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Presenters;

namespace OldBoardGamesNeedLoveToo.Web.UserControls
{
    [PresenterBinding(typeof(RatingPresenter))]
    public partial class Rating : MvpUserControl<RatingViewModel>, IRatingView
    {
        public bool IsVisible
        {
            get
            {
                return this.ButtomRateSumbit.Visible;
            }
            set
            {
                this.ButtomRateSumbit.Visible = value;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return this.RatingAjaxToolkit.ReadOnly;
            }
            set
            {
                this.RatingAjaxToolkit.ReadOnly = value;
            }
        }

        public event EventHandler<RatingValueEventArgs> onPageInit;
        public event EventHandler<RatingValueEventArgs> OnRatingChanged;

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = GetUsernameFromQueryString();
            this.onPageInit?.Invoke(sender, new RatingValueEventArgs(null, username));
            this.RatingAjaxToolkit.CurrentRating = (int) this.Model.AverageRating;

            if (!IsPostBack)
            {
                this.DataBind();
            }
        }

        protected void RatingAjaxToolkit_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
        {
            int ratingValue = this.RatingAjaxToolkit.CurrentRating;
            string username = GetUsernameFromQueryString();
            this.OnRatingChanged?.Invoke(sender, new RatingValueEventArgs(ratingValue, username));
        }

        private string GetUsernameFromQueryString()
        {
            return this.Request.QueryString["username"];
        }
    }
}
using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class RatingPresenter : Presenter<IRatingView>
    {
        private readonly IUsersService usersService;
        public RatingPresenter(IRatingView view, IUsersService usersService)
            : base(view)
        {
            Guard.WhenArgument(usersService, "usersService").IsNull().Throw();

            this.usersService = usersService;

            this.View.onPageInit += this.View_onPageInit;
            this.View.OnRatingChanged += this.View_OnRatingChanged;
        }

        private void View_OnRatingChanged(object sender, CustomEventArgs.RatingValueEventArgs e)
        {
            this.usersService.UpdateUserCustomInfoWithRatingValue(e.RatingValue, e.Username);
        }

        private void View_onPageInit(object sender, CustomEventArgs.RatingValueEventArgs e)
        {
            this.View.Model.AverageRating = this.usersService.GetAverageUserRating(e.Username);
        }
    }
}

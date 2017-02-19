using System;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IRatingView : IView<RatingViewModel>
    {
        event EventHandler<RatingValueEventArgs> onPageInit;

        event EventHandler<RatingValueEventArgs> OnRatingChanged;
    }
}
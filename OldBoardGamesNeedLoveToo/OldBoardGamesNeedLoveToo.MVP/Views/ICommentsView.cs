using System;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface ICommentsView : IView<CommentsViewModel>
    {
        event EventHandler<CommentsByGameIdEventArgs> OnGetData;

        event EventHandler<CommentDetailsEventArgs> OnSubmitComment;
    }
}
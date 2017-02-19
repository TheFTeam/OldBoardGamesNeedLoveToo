using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class CommentsPresenter : Presenter<ICommentsView>
    {
        private readonly ICommentsService commentsService;

        public CommentsPresenter(ICommentsView view, ICommentsService commentsService)
            : base(view)
        {
            Guard.WhenArgument(commentsService, "commentsService").IsNull().Throw();

            this.commentsService = commentsService;

            this.View.OnGetData += this.View_OnGetData;
            this.View.OnSubmitComment += this.View_OnSubmitComment;
        }

        private void View_OnGetData(object sender, CustomEventArgs.CommentsByGameIdEventArgs e)
        {
            this.View.Model.Comments = this.commentsService.GetAllCommentsByGameId(e.GameId);
        }

        private void View_OnSubmitComment(object sender, CustomEventArgs.CommentDetailsEventArgs e)
        {
            Comment commentToAdd = this.commentsService.CreateComment(e.Content, e.GameId, e.PostedByUserName);
            this.commentsService.AddComment(commentToAdd);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Web;

using WebFormsMvp;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using OldBoardGamesNeedLoveToo.Auth;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Web.UserControls
{
    [PresenterBinding(typeof(CommentsPresenter))]
    public partial class CommentsList : MvpUserControl<CommentsViewModel>, ICommentsView
    {
        public bool IsVisible
        {
            get
            {
                return this.Visible;
            }
            set
            {
                this.Visible = value;
            }
        }

        public event EventHandler<CommentDetailsEventArgs> OnSubmitComment;
        public event EventHandler<CommentsByGameIdEventArgs> OnGetData;

        protected void ButtonSubmitComment_Click(object sender, EventArgs e)
        {
            string content = this.TextBoxInputComment.Text;
            Guid gameId = GetGameIdFromQueryString();
            string username = GetUsernameFromApplicationUserManager();
            this.OnSubmitComment?.Invoke(this, new CommentDetailsEventArgs(content, gameId, username));
            this.TextBoxInputComment.Text = string.Empty;
        }

        public IEnumerable<Comment> RepeaterComments_GetData()
        {
            var gameId = GetGameIdFromQueryString();
            this.OnGetData?.Invoke(this, new CommentsByGameIdEventArgs(gameId));

            return this.Model.Comments;
        }

        private Guid GetGameIdFromQueryString()
        {
            return new Guid(this.Request.QueryString["id"]);
        }

        public string GetUsernameFromApplicationUserManager()
        {
            ApplicationUser user = HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(HttpContext.Current.User.Identity.GetUserId());

            return user.UserName;
        }
    }
}
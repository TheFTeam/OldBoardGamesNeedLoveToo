using System;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class CommentDetailsEventArgs : EventArgs
    {
        public CommentDetailsEventArgs(string content, Guid gameId, string postedByUserName)
        {
            this.Content = content;
            this.GameId = gameId;
            this.PostedByUserName = postedByUserName;
        }

        public string Content { get; set; }

        public Guid GameId { get; set; }

        public string PostedByUserName { get; set; }
    }
}
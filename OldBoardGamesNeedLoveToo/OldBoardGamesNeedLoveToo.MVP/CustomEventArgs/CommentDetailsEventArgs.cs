using System;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class CommentDetailsEventArgs : EventArgs
    {
        public CommentDetailsEventArgs(string content, Guid gameId)
        {
            this.Content = content;
            this.GameId = gameId;
        }

        public string Content { get; set; }

        public Guid GameId { get; set; }
    }
}
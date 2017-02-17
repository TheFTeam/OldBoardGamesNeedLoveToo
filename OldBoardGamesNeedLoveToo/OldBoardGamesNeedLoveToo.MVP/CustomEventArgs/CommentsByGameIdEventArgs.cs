using System;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class CommentsByGameIdEventArgs : EventArgs
    {
        public CommentsByGameIdEventArgs(Guid id)
        {
            this.GameId = id;
        }

        public Guid GameId { get; set; }
    }
}
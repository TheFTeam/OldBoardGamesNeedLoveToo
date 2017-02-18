using System;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class GameDetailsEventArgs :EventArgs
    {
        public GameDetailsEventArgs(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; private set; }
    }
}
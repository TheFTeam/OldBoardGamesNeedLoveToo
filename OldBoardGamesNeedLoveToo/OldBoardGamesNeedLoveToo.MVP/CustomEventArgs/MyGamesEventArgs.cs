using System;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class MyGamesEventArgs
    {
        public MyGamesEventArgs(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
    }
}
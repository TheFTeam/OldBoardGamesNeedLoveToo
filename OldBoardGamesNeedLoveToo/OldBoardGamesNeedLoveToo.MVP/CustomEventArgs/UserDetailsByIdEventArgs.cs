using System;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class UserDetailsByIdEventArgs
    {
        public UserDetailsByIdEventArgs(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; private set; }
    }
}
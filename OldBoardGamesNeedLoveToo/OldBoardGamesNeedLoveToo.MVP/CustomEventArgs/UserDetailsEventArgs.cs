using System;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class UserDetailsEventArgs
    {
        public UserDetailsEventArgs(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; private set; }
    }
}
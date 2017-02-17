using System;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class UserDetailsByUsernameEventArgs : EventArgs
    {
        public UserDetailsByUsernameEventArgs(string username)
        {
            this.Username = username;
        }

        public string Username { get; set; }
    }
}
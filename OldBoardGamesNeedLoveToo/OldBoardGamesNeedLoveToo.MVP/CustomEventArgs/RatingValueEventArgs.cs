using System;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class RatingValueEventArgs : EventArgs
    {
        public RatingValueEventArgs(int? ratingValue, string username)
        {
            this.RatingValue = ratingValue;
            this.Username = username;
        }

        public int? RatingValue { get; set; }

        public string Username { get; set; }
    }
}
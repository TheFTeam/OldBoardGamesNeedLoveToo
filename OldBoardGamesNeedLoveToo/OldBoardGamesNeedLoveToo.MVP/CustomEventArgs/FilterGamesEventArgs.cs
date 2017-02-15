using System;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class FilterGamesEventArgs : EventArgs
    {
        public string MinPrice { get; set; }

        public string MaxPrice { get; set; }

        public string MinNumberOfPlayers { get; set; }

        public string MaxNumberOfPlayers { get; set; }

        public string MinPlayersAge { get; set; }

        public string MaxPlayersAge { get; set; }

        public string CategoryId { get; set; }

        public string Condition { get; set; }

        public string ReleasedateFrom { get; set; }

        public string ReleaseDateTo { get; set; }
    }
}
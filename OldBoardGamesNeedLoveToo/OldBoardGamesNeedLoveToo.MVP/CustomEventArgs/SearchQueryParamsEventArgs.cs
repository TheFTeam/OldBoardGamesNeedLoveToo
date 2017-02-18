using System;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class SearchQueryParamsEventArgs : EventArgs
    {
        public SearchQueryParamsEventArgs(string queryParams)
        {
            this.QueryParams = queryParams;
        }

        public string QueryParams { get; private set; }
    }
}
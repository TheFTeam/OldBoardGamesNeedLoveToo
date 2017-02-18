using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public class SearchViewModel : ISearchViewModel
    {
        public IEnumerable<Game> Games { get; set; }
    }
}
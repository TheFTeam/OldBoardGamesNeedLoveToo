using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public interface ISearchViewModel
    {
        IEnumerable<Game> Games { get; set; }
    }
}
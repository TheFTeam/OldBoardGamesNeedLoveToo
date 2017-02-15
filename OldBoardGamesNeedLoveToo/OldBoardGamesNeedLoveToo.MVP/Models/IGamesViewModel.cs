using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public interface IGamesViewModel
    {
        IEnumerable<Game> Games { get; set; }

        IEnumerable<Category> Categories { get; set; }
    }
}
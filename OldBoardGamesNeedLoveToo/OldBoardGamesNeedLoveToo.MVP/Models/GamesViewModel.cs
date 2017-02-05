using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public class GamesViewModel : IGamesViewModel
    {
        public IEnumerable<Game> Games { get; set; }
    }
}

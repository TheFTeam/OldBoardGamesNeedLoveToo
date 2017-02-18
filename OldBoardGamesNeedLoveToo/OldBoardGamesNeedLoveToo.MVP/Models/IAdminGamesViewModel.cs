using OldBoardGamesNeedLoveToo.Models;
using System.Collections.Generic;


namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public interface IAdminGamesViewModel
    {
        IEnumerable<Game> Games { get; set; }

    }
}

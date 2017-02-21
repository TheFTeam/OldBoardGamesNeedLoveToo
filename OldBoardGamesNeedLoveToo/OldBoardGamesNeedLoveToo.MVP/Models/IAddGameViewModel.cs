using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public interface IAddGameViewModel
    {
        Game Game { get; set; }

        IEnumerable<Category> Categories { get; set; }
    }
}
using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public interface IUsersViewModel
    {
        IEnumerable<UserCustomInfo> Users { get; set; }

        IEnumerable<Game> Games { get; set; }
    }
}
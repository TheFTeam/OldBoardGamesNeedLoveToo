using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public interface ICommentsViewModel
    {
        IEnumerable<Comment> Comments { get; set; }
    }
}
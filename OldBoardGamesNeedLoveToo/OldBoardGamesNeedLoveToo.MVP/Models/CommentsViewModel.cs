using System.Collections.Generic;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public class CommentsViewModel : ICommentsViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
    }
}
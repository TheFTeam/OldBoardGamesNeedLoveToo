using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public class AddGameViewModel : IAddGameViewModel
    {
        public Game Game { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
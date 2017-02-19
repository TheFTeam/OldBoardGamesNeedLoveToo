using OldBoardGamesNeedLoveToo.Models;
using System;
using System.Collections.Generic;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public class AddGameViewModel : IAddGameViewModel
    {
        public string Condition { get; set; }
                
        public string Content { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public string Language { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string Producer { get; set; }

        public string ReleaseDate { get; set; }

        public string MinPlayers { get; set; }

        public string MaxPlayers { get; set; }

        public string MinAgeOfPlayers { get; set; }

        public string MaxAgeOfPlayers { get; set; }

        public Guid OwnerId { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public ICollection<string> SelectedCategoryIds { get; set; }
    }
}
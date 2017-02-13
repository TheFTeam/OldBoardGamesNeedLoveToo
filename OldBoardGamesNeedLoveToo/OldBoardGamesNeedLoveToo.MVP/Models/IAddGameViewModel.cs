using System;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public interface IAddGameViewModel
    {
        string Name { get; set; }

        byte[] Image { get; set; }

        string Producer { get; set; }

        string Price { get; set; }

        string Description { get; set; }

        string Content { get; set; }

        string Condition { get; set; }

        string ReleaseDate { get; set; }

        string Language { get; set; }

        string MinPlayers { get; set; }

        string MaxPlayers { get; set; }

        string MinAgeOfPlayers { get; set; }

        string MaxAgeOfPlayers { get; set; }

        Guid OwnerId { get; set; }
    }
}
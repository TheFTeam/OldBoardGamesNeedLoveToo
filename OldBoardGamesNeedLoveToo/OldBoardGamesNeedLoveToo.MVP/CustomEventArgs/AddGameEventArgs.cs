using System;
using System.Collections.Generic;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class AddGameEventArgs : EventArgs
    {
        public AddGameEventArgs(string condition, string content, string description, byte[] image, 
            string language, string name, string price, string producer, string releaseDate, string minPlayers,
            string maxPlayers, string minAgeOfPlayers, string maxAgeOfPlayers, Guid ownerId,
            ICollection<string> selectedCategoryIds)
        {
            this.Condition = condition;
            this.Content = content;
            this.Description = description;
            this.Image = image;
            this.Language = language;
            this.MinPlayers = minPlayers;
            this.MaxPlayers = maxPlayers;
            this.MinAgeOfPlayers = minAgeOfPlayers;
            this.MaxAgeOfPlayers = maxAgeOfPlayers;
            this.Name = name;
            this.Price = price;
            this.ReleaseDate = releaseDate;
            this.OwnerId = ownerId;
            this.SelectedCategoryIds = selectedCategoryIds;
            this.Producer = producer;
        }

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

        public ICollection<string> SelectedCategoryIds { get; set; }
    }
}
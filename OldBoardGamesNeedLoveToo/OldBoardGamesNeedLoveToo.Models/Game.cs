using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

using OldBoardGamesNeedLoveToo.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBoardGamesNeedLoveToo.Models
{
    public class Game : IGame
    {
        private ICollection<Category> categories;
        private ICollection<Comment> comments;

        public Game()
        {
            this.categories = new HashSet<Category>();
            this.comments = new HashSet<Comment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Desription { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Contents { get; set; }

        public byte[] Image { get; set; }

        [Required]
        public ConditionType Condition { get; set; }

        [Min(1)]
        public int MinPlayers { get; set; }

        [Max(100)]
        public int MaxPlayers { get; set; }

        [Range(2, 100)]
        public int MinAgeOfPlayers { get; set; }

        [Range(2, 100)]
        public int MaxAgeOfPlayers { get; set; }

        [Required]
        public string Language { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public DateTime AddedOnDate
        {
            get
            {
                return DateTime.Now;
            }
        }

        public string Producer { get; set; }

        [Required]
        [Min(0.0)]
        public decimal Price { get; set; }

        public bool isSold { get; set; }

        public Guid OwnerId { get; set; }

        public virtual UserCustomInfo Owner { get; set; }

        public Guid? BuyerId { get; set; }

        public virtual UserCustomInfo Buyer { get; set; }

        public virtual ICollection<Category> Categories
        {
            get
            {
                return this.categories;
            }
            set
            {
                this.categories = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
    }
}
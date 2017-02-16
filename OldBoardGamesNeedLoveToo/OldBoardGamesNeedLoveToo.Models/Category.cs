using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBoardGamesNeedLoveToo.Models
{
    public class Category
    {
        private ICollection<Game> games;

        public Category()
        {
            this.games = new HashSet<Game>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Index(IsUnique =true)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Game> Games
        {
            get
            {
                return this.games;
            }
            set
            {
                this.games = value;
            }
        }
    }
}
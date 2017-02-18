using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBoardGamesNeedLoveToo.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Content { get; set; }

        public DateTime PostedOnDate { get; set; }

        //public Guid PostedByUserId { get; set; }

        //public UserCustomInfo PostedByUser { get; set; }

        public Guid GameId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }
    }
}
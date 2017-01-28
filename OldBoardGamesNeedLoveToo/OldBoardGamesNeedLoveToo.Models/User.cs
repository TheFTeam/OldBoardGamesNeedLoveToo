using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBoardGamesNeedLoveToo.Models
{
    public class User
    {
        private ICollection<Game> boughtGames;
        private ICollection<Game> sellingGame;

        public User()
        {
            this.boughtGames = new HashSet<Game>();
            this.sellingGame = new HashSet<Game>();
        }
        public int Id { get; set; }

        public UserRoleType Role { get; set; }

        [Index(IsUnique = true)]
        [MinLength(2)]
        [MaxLength(30)]
        public string Username { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }

        public string HashPassword { get; set; }

        [MinLength(4)]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [ForeignKey("BuyerId")]
        [Column("BoughtGames")]

        public virtual ICollection<Game> BoughtGames
        {
            get
            {
                return this.boughtGames;
            }
            set
            {
                this.boughtGames = value;
            }
        }

        [ForeignKey("OwnerId")]
        [Column("SellingGames")]

        public virtual ICollection<Game> SellingGames
        {
            get
            {
                return this.sellingGame;
            }
            set
            {
                this.sellingGame = value;
            }
        }
    }
}
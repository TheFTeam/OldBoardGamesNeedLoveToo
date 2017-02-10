using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

using OldBoardGamesNeedLoveToo.Models.Contracts;

namespace OldBoardGamesNeedLoveToo.Models
{
    public class UserCustomInfo : IUserCustomInfo
    {
        private ICollection<Game> boughtGames;
        private ICollection<Game> sellingGame;
        private UserRoleType role;

        public UserCustomInfo()
        {
            this.boughtGames = new HashSet<Game>();
            this.sellingGame = new HashSet<Game>();
        }
        public Guid Id { get; set; }

        public UserRoleType Role
        {
            get
            {
                return UserRoleType.User;
            }
            set
            {
                this.role = value;
            }
        }

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

        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual IPrincipal ApplicationUser { get; set; }

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
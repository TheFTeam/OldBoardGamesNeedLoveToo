using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OldBoardGamesNeedLoveToo.Models.Contracts;

namespace OldBoardGamesNeedLoveToo.Models
{
    public class UserCustomInfo : IUserCustomInfo
    {
        private ICollection<Game> boughtGames;
        private ICollection<Game> sellingGame;
        //private ICollection<Comment> comments;
        private UserRoleType role;

        public UserCustomInfo()
        {
            this.boughtGames = new HashSet<Game>();
            this.sellingGame = new HashSet<Game>();
            //this.comments = new HashSet<Comment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string ApplicationUserId { get; set; }

        public double AverageRatingResult { get; set; }

        public int NumberOfUsersGivenRating { get; set; }

        public int SumOfUsersRating { get; set; }

        public byte[] ProfilePricture { get; set; }

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

        //public virtual ICollection<Comment> Comments
        //{
        //    get
        //    {
        //        return this.comments;
        //    }
        //    set
        //    {
        //        this.comments = value;
        //    }
        //}
    }
}
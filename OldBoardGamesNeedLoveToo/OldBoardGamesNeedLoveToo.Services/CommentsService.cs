using System;
using System.Collections.Generic;
using System.Linq;

using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> commentsRepository;
        private readonly IUnitOfWork unitOfWork;

        public CommentsService(IRepository<Comment> commentsRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(commentsRepository, "commentsRepository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.commentsRepository = commentsRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddComment(Comment category)
        {
            this.commentsRepository.Add(category);
            this.unitOfWork.Commit();
        }

        public Comment CreateComment(string content, Guid gameId)
        {
            return new Comment()
            {
                GameId = gameId,
                Content = content,
                PostedOnDate = DateTime.Now
            };
        }

        public IEnumerable<Comment> GetAllCommentsByGameId(Guid id)
        {
            return this.commentsRepository.GetAll().Where(c => c.GameId == id);
        }

        public Comment GetCommentById(object id)
        {
            return this.commentsRepository.GetById(id);
        }
    }
}
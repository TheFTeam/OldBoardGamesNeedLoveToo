using System;
using System.Collections.Generic;

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

        public void AddComment(Comment comment)
        {
            Guard.WhenArgument(comment, "comment").IsNull().Throw();

            this.commentsRepository.Add(comment);
            this.unitOfWork.Commit();
        }

        public Comment CreateComment(string content, Guid gameId, string username)
        {
            Guard.WhenArgument(content, "content").IsNull().Throw();
            Guard.WhenArgument(gameId, "gameId").IsEmptyGuid().Throw();
            Guard.WhenArgument(username, "username").IsNull().Throw();

            return new Comment()
            {
                GameId = gameId,
                Content = content,
                PostedOnDate = DateTime.Now,
                PostedByUserName = username             
            };
        }

        public IEnumerable<Comment> GetAllCommentsByGameId(Guid id)
        {
            Guard.WhenArgument(id, "id").IsEmptyGuid().Throw();

            return this.commentsRepository.GetAll(c => c.GameId == id, c => c.PostedOnDate);
        }

        public Comment GetCommentById(object id)
        {
            Guard.WhenArgument(id, "id").IsNull().Throw();

            return this.commentsRepository.GetById(id);
        }
    }
}
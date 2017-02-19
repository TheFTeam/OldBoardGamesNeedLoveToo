using System;
using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Contracts
{
    public interface ICommentsService
    {
        Comment GetCommentById(object id);

        IEnumerable<Comment> GetAllCommentsByGameId(Guid id);

        Comment CreateComment(string content, Guid gameId, string username);

        void AddComment(Comment category);
    }
}
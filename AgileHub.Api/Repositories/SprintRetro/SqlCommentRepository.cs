using AgileHub.Api.Data;
using AgileHub.Api.Models.Domain.SprintRetro;
using Microsoft.EntityFrameworkCore;

namespace AgileHub.Api.Repositories.SprintRetro
{
    public class SqlCommentRepository : ICommentRepository
    {
        private readonly AgileHubDbContext dbContext;

        public SqlCommentRepository(AgileHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Comment> CreateAsync(Comment comment)
        {
            await dbContext.Comments.AddAsync(comment);
            await dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> DeleteAsync(Guid id)
        {
            var comment = await dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (comment == null)
            {
                return null;
            }

            dbContext.Remove(comment);
            await dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await dbContext.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(Guid id)
        {
            return await dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Comment?> UpdateAsync(Guid id, Comment comment)
        {
            var existingComment = await dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (existingComment == null)
            {
                return null;
            }
            existingComment.Description = comment.Description;
            existingComment.UserId = comment.UserId;
            existingComment.NoteId = comment.NoteId;

            await dbContext.SaveChangesAsync();
            return existingComment;
        }
    }
}

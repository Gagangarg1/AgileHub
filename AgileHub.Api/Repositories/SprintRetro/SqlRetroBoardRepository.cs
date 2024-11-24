using AgileHub.Api.Data;
using AgileHub.Api.Models.Domain.SprintRetro;
using Microsoft.EntityFrameworkCore;

namespace AgileHub.Api.Repositories.SprintRetro
{
    public class SqlRetroBoardRepository : IRetroBoardRepository
    {
        private readonly AgileHubDbContext dbContext;

        public SqlRetroBoardRepository(AgileHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<RetroBoard> CreateAsync(RetroBoard retroBoard)
        {
            await dbContext.RetroBoards.AddAsync(retroBoard);
            await dbContext.SaveChangesAsync();
            return retroBoard;
        }

        public async Task<RetroBoard?> DeleteAsync(Guid id)
        {
            var retroBoard = await dbContext.RetroBoards.Include(x => x.RetroBoardUsers).Include(x => x.BoardColumns).ThenInclude(x => x.Notes).ThenInclude(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
            if (retroBoard == null)
            {
                return null;
            }

            dbContext.Remove(retroBoard);
            await dbContext.SaveChangesAsync();
            return retroBoard;
        }

        public async Task<List<RetroBoard>> GetAllAsync()
        {
            return await dbContext.RetroBoards.Include(x => x.RetroBoardUsers).Include(x => x.BoardColumns).ThenInclude(x => x.Notes).ThenInclude(x => x.Comments).ToListAsync();
        }

        public async Task<RetroBoard?> GetByIdAsync(Guid id)
        {
            return await dbContext.RetroBoards.Include(x => x.RetroBoardUsers).Include(x => x.BoardColumns).ThenInclude(x => x.Notes).ThenInclude(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<RetroBoard?> UpdateAsync(Guid id, RetroBoard retroBoard)
        {
            var existingRetroBoard = await dbContext.RetroBoards.Include(x => x.RetroBoardUsers).Include(x => x.BoardColumns).ThenInclude(x => x.Notes).ThenInclude(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
            if (existingRetroBoard == null)
            {
                return null;
            }
            existingRetroBoard.Name = retroBoard.Name;

            await dbContext.SaveChangesAsync();
            return existingRetroBoard;
        }
    }
}

using AgileHub.Api.Data;
using AgileHub.Api.Models.Domain.SprintRetro;
using Microsoft.EntityFrameworkCore;

namespace AgileHub.Api.Repositories.SprintRetro
{
    public class SqlBoardColumnRepository : IBoardColumnRepository
    {
        private readonly AgileHubDbContext dbContext;

        public SqlBoardColumnRepository(AgileHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<BoardColumn> CreateAsync(BoardColumn boardColumn)
        {
            await dbContext.BoardColumns.AddAsync(boardColumn);
            await dbContext.SaveChangesAsync();
            return boardColumn;
        }

        public async Task<BoardColumn?> DeleteAsync(Guid id)
        {
            var boardColumn = await dbContext.BoardColumns.Include(x => x.Notes).ThenInclude(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
            if (boardColumn == null)
            {
                return null;
            }

            dbContext.Remove(boardColumn);
            await dbContext.SaveChangesAsync();
            return boardColumn;
        }

        public async Task<List<BoardColumn>> GetAllAsync()
        {
            return await dbContext.BoardColumns.Include(x => x.Notes).ThenInclude(x => x.Comments).ToListAsync();
        }

        public async Task<BoardColumn?> GetByIdAsync(Guid id)
        {
            return await dbContext.BoardColumns.Include(x => x.Notes).ThenInclude(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BoardColumn?> UpdateAsync(Guid id, BoardColumn boardColumn)
        {
            var existingBoardColumn = await dbContext.BoardColumns.Include(x => x.Notes).ThenInclude(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
            if (existingBoardColumn == null)
            {
                return null;
            }
            existingBoardColumn.Id = boardColumn.Id;
            existingBoardColumn.Name = boardColumn.Name;
            existingBoardColumn.RetroBoardId = boardColumn.RetroBoardId;

            await dbContext.SaveChangesAsync();
            return existingBoardColumn;
        }
    }
}

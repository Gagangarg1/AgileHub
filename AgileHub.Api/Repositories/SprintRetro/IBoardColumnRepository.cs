using AgileHub.Api.Models.Domain.SprintRetro;

namespace AgileHub.Api.Repositories.SprintRetro
{
    public interface IBoardColumnRepository
    {
        Task<List<BoardColumn>> GetAllAsync();
        Task<BoardColumn?> GetByIdAsync(Guid id);
        Task<BoardColumn> CreateAsync(BoardColumn boardColumn);
        Task<BoardColumn?> UpdateAsync(Guid id, BoardColumn boardColumn);
        Task<BoardColumn?> DeleteAsync(Guid id);
    }
}

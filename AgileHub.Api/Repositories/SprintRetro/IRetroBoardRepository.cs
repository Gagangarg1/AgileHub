using AgileHub.Api.Models.Domain.SprintRetro;

namespace AgileHub.Api.Repositories.SprintRetro
{
    public interface IRetroBoardRepository
    {
        Task<List<RetroBoard>> GetAllAsync();
        Task<RetroBoard?> GetByIdAsync(Guid id);
        Task<RetroBoard> CreateAsync(RetroBoard retroBoard);
        Task<RetroBoard?> UpdateAsync(Guid id, RetroBoard retroBoard);
        Task<RetroBoard?> DeleteAsync(Guid id);
    }
}

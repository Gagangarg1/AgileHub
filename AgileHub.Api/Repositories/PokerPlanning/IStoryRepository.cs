using AgileHub.Api.Models.Domain.PokerPlanning;

namespace AgileHub.Api.Repositories.PokerPlanning
{
    public interface IStoryRepository
    {
        Task<List<Story>> GetAllAsync();
        Task<List<Story>> GetAllByRoomIdAsync(Guid roomId);
        Task<Story?> GetByIdAsync(Guid id);
        Task<Story> CreateAsync(Story story);
        Task<Story?> UpdateAsync(Guid id, Story story);
        Task<Story?> DeleteAsync(Guid id);
    }
}

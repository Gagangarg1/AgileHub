using AgileHub.Api.Models.Domain.PokerPlanning;

namespace AgileHub.Api.Repositories.PokerPlanning
{
    public interface IVoteRepository
    {
        Task<List<Vote>> GetAllAsync();
        Task<List<Vote>> GetByStoryIdAsync(Guid storyId);
        Task<Vote?> GetByIdAsync(Guid id);
        Task<Vote> CreateAsync(Vote vote);
        Task<Vote?> UpdateAsync(Guid id, Vote vote);
        Task<Vote?> DeleteAsync(Guid id);
    }
}

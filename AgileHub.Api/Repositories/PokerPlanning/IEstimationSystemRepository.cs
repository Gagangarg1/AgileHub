using AgileHub.Api.Models.Domain.PokerPlanning;

namespace AgileHub.Api.Repositories.PokerPlanning
{
    public interface IEstimationSystemRepository
    {
        Task<List<EstimationSystem>> GetAllAsync();
        Task<EstimationSystem?> GetByIdAsync(Guid id);
        Task<EstimationSystem> CreateAsync(EstimationSystem estimationSystem);
        Task<EstimationSystem?> UpdateAsync(Guid id, EstimationSystem estimationSystem);
        Task<EstimationSystem?> DeleteAsync(Guid id);
    }
}

using AgileHub.Api.Models.Domain.PokerPlanning;

namespace AgileHub.Api.Repositories.PokerPlanning
{
    public interface IPlanningRoomRepository
    {
        Task<List<PlanningRoom>> GetAllAsync();
        Task<PlanningRoom?> GetByIdAsync(Guid id);
        Task<PlanningRoom> CreateAsync(PlanningRoom planningRoom);
        Task<PlanningRoom?> UpdateAsync(Guid id, PlanningRoom planningRoom);
        Task<PlanningRoom?> DeleteAsync(Guid id);
    }
}

using AgileHub.Api.Models.Domain;

namespace AgileHub.Api.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<List<User>> GetByPlanningRoomIdAsync(Guid planningRoomId);
        Task<List<User>> GetByRetroBoardIdAsync(Guid retroBoardId);
        Task<User?> GetByIdAsync(Guid id);
        Task<User> CreateAsync(User user);
        Task<User?> UpdateAsync(Guid id, User user);
        Task<User?> DeleteAsync(Guid id);
    }
}

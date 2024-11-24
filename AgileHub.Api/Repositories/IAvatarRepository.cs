using AgileHub.Api.Models.Domain;

namespace AgileHub.Api.Repositories
{
    public interface IAvatarRepository
    {
        Task<List<Avatar>> GetAllAsync();
        Task<Avatar?> GetByIdAsync(Guid id);
        Task<Avatar> CreateAsync(Avatar avatar);
        Task<Avatar?> UpdateAsync(Guid id, Avatar avatar);
        Task<Avatar?> DeleteAsync(Guid id);
    }
}

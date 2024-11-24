using AgileHub.Api.Models.Domain.SprintRetro;

namespace AgileHub.Api.Repositories.SprintRetro
{
    public interface INoteRepository
    {
        Task<List<Note>> GetAllAsync();
        Task<Note?> GetByIdAsync(Guid id);
        Task<Note> CreateAsync(Note note);
        Task<Note?> UpdateAsync(Guid id, Note note);
        Task<Note?> DeleteAsync(Guid id);
    }
}

using AgileHub.Api.Data;
using AgileHub.Api.Models.Domain.SprintRetro;
using Microsoft.EntityFrameworkCore;

namespace AgileHub.Api.Repositories.SprintRetro
{
    public class SqlNoteRepository : INoteRepository
    {
        private readonly AgileHubDbContext dbContext;

        public SqlNoteRepository(AgileHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Note> CreateAsync(Note note)
        {
            await dbContext.Notes.AddAsync(note);
            await dbContext.SaveChangesAsync();
            return note;
        }

        public async Task<Note?> DeleteAsync(Guid id)
        {
            var note = await dbContext.Notes.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
            if (note == null)
            {
                return null;
            }

            dbContext.Remove(note);
            await dbContext.SaveChangesAsync();
            return note;
        }

        public async Task<List<Note>> GetAllAsync()
        {
            return await dbContext.Notes.Include(x => x.Comments).ToListAsync();
        }

        public async Task<Note?> GetByIdAsync(Guid id)
        {
            return await dbContext.Notes.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Note?> UpdateAsync(Guid id, Note note)
        {
            var existingNote = await dbContext.Notes.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
            if (existingNote == null)
            {
                return null;
            }
            existingNote.Description = note.Description;
            existingNote.UserId = note.UserId;
            existingNote.BoardColumnId = note.BoardColumnId;

            await dbContext.SaveChangesAsync();
            return existingNote;
        }
    }
}

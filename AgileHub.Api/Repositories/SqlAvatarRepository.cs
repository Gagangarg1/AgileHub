using AgileHub.Api.Data;
using AgileHub.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgileHub.Api.Repositories
{
    public class SqlAvatarRepository : IAvatarRepository
    {
        private readonly AgileHubDbContext dbContext;

        public SqlAvatarRepository(AgileHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Avatar> CreateAsync(Avatar avatar)
        {
            await dbContext.Avatars.AddAsync(avatar);
            await dbContext.SaveChangesAsync();
            return avatar;
        }

        public async Task<Avatar?> DeleteAsync(Guid id)
        {
            var avatar = await dbContext.Avatars.FirstOrDefaultAsync(x => x.Id == id);
            if (avatar == null)
            {
                return null;
            }

            dbContext.Remove(avatar);
            await dbContext.SaveChangesAsync();
            return avatar;
        }

        public async Task<List<Avatar>> GetAllAsync()
        {
            return await dbContext.Avatars.ToListAsync();
        }

        public async Task<Avatar?> GetByIdAsync(Guid id)
        {
            return await dbContext.Avatars.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Avatar?> UpdateAsync(Guid id, Avatar avatar)
        {
            var existingAvatar = await dbContext.Avatars.FirstOrDefaultAsync(x => x.Id == id);
            if (existingAvatar == null)
            {
                return null;
            }

            existingAvatar.Name = avatar.Name;
            existingAvatar.Extention = avatar.Extention;
            existingAvatar.Location = avatar.Location;

            await dbContext.SaveChangesAsync();
            return existingAvatar;
        }
    }
}

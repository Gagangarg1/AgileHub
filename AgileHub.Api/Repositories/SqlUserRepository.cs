using AgileHub.Api.Data;
using AgileHub.Api.Models.Domain;
using AgileHub.Api.Models.Domain.PokerPlanning;
using Microsoft.EntityFrameworkCore;

namespace AgileHub.Api.Repositories
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly AgileHubDbContext dbContext;

        public SqlUserRepository(AgileHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            if(user?.Id !=null)
            {
                return await dbContext.Users.Include(x => x.Avatar).FirstOrDefaultAsync(x => x.Id == user.Id);
            }
            return user;
        }

        public async Task<User?> DeleteAsync(Guid id)
        {
            var user = await dbContext.Users.Include(x => x.Avatar).FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }

            dbContext.Remove(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.Include(x => x.Avatar).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await dbContext.Users.Include(x => x.Avatar).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetByPlanningRoomIdAsync(Guid planningRoomId)
        {
            return await dbContext.Users.Where(x => x.PlanningRoomId == planningRoomId).Include(x => x.Avatar).ToListAsync();
        }

        public async Task<List<User>> GetByRetroBoardIdAsync(Guid retroBoardId)
        {
            return await dbContext.Users.Where(x => x.RetroBoardId == retroBoardId).Include(x => x.Avatar).ToListAsync();
        }

        public async Task<User?> UpdateAsync(Guid id, User user)
        {
            var existingUser = await dbContext.Users.Include(x => x.Avatar).FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.AvatarId = user.AvatarId;
            if (user.PlanningRoomId != null)
            {
                existingUser.PlanningRoomId = user.PlanningRoomId;
            }
            if (user.RetroBoardId != null)
            {
                existingUser.RetroBoardId = user.RetroBoardId;
            }

            await dbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}

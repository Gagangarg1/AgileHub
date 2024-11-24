using AgileHub.Api.Data;
using AgileHub.Api.Models.Domain.PokerPlanning;
using Microsoft.EntityFrameworkCore;

namespace AgileHub.Api.Repositories.PokerPlanning
{
    public class SqlStoryRepository : IStoryRepository
    {
        private readonly AgileHubDbContext dbContext;

        public SqlStoryRepository(AgileHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Story> CreateAsync(Story story)
        {
            await dbContext.Stories.AddAsync(story);
            await dbContext.SaveChangesAsync();
            return story;
        }

        public async Task<Story?> DeleteAsync(Guid id)
        {
            var story = await dbContext.Stories.FirstOrDefaultAsync(x => x.Id == id);
            if (story == null)
            {
                return null;
            }

            dbContext.Remove(story);
            await dbContext.SaveChangesAsync();
            return story;
        }

        public async Task<List<Story>> GetAllAsync()
        {
            return await dbContext.Stories.Include(x => x.Votes).ThenInclude(x => x.User).ToListAsync();
        }

        public async Task<List<Story>> GetAllByRoomIdAsync(Guid roomId)
        {
            return await dbContext.Stories.Where(x => x.PlanningRoomId == roomId).Include(x => x.Votes).ThenInclude(x => x.User).ToListAsync();
        }

        public async Task<Story?> GetByIdAsync(Guid id)
        {
            return await dbContext.Stories.Include(x => x.Votes).ThenInclude(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Story?> UpdateAsync(Guid id, Story story)
        {
            var existingStory = await dbContext.Stories.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStory == null)
            {
                return null;
            }
            existingStory.Title = story.Title;
            existingStory.JiraId = story.JiraId;
            existingStory.Votes = story.Votes;
            existingStory.PlanningRoomId = story.PlanningRoomId;

            await dbContext.SaveChangesAsync();
            return existingStory;
        }
    }
}

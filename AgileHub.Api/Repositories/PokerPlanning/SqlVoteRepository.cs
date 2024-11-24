using AgileHub.Api.Data;
using AgileHub.Api.Models.Domain.PokerPlanning;
using Microsoft.EntityFrameworkCore;

namespace AgileHub.Api.Repositories.PokerPlanning
{
    public class SqlVoteRepository : IVoteRepository
    {
        private readonly AgileHubDbContext dbContext;

        public SqlVoteRepository(AgileHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Vote> CreateAsync(Vote vote)
        {
            var existingVote = await dbContext.Votes.FirstOrDefaultAsync(x => x.UserId == vote.UserId && x.StoryId == vote.StoryId);
            if (existingVote != null)
            {
                existingVote.StoryPoint = vote.StoryPoint;
                existingVote.User = vote.User;
                existingVote.Story = vote.Story;
                await dbContext.SaveChangesAsync();
                return existingVote;
            }

            await dbContext.Votes.AddAsync(vote);
            await dbContext.SaveChangesAsync();
            return vote;
        }

        public async Task<Vote?> DeleteAsync(Guid id)
        {
            var vote = await dbContext.Votes.FirstOrDefaultAsync(x => x.Id == id);
            if (vote == null)
            {
                return null;
            }

            dbContext.Remove(vote);
            await dbContext.SaveChangesAsync();
            return vote;
        }

        public async Task<List<Vote>> GetAllAsync()
        {
            return await dbContext.Votes.Include(x => x.User).Include(x => x.Story).ToListAsync();
        }

        public async Task<Vote?> GetByIdAsync(Guid id)
        {
            return await dbContext.Votes.Include(x => x.User).Include(x => x.Story).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Vote>> GetByStoryIdAsync(Guid storyId)
        {
            return await dbContext.Votes.Where(x => x.StoryId == storyId).Include(x => x.User).Include(x => x.Story).ToListAsync();
        }

        public async Task<Vote?> UpdateAsync(Guid id, Vote vote)
        {
            var existingVote = await dbContext.Votes.FirstOrDefaultAsync(x => x.Id == id);
            if (existingVote == null)
            {
                return null;
            }
            existingVote.StoryPoint = vote.StoryPoint;
            existingVote.User = vote.User;
            existingVote.Story = vote.Story;

            await dbContext.SaveChangesAsync();
            return existingVote;
        }
    }
}

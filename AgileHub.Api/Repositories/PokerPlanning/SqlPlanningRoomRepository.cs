using AgileHub.Api.Data;
using AgileHub.Api.Models.Domain.PokerPlanning;
using Microsoft.EntityFrameworkCore;

namespace AgileHub.Api.Repositories.PokerPlanning
{
    public class SqlPlanningRoomRepository : IPlanningRoomRepository
    {
        private readonly AgileHubDbContext dbContext;
        public SqlPlanningRoomRepository(AgileHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<PlanningRoom> CreateAsync(PlanningRoom planningRoom)
        {
            await dbContext.PlanningRooms.AddAsync(planningRoom);
            await dbContext.SaveChangesAsync();
            return planningRoom;
        }

        public async Task<PlanningRoom?> DeleteAsync(Guid id)
        {
            var planningRoom = await dbContext.PlanningRooms.FirstOrDefaultAsync(x => x.Id == id);
            if (planningRoom == null)
            {
                return null;
            }

            dbContext.Remove(planningRoom);
            await dbContext.SaveChangesAsync();
            return planningRoom;
        }

        public async Task<List<PlanningRoom>> GetAllAsync()
        {
            return await dbContext.PlanningRooms.Include(x => x.EstimationSystem).Include(x => x.PlanningRoomUsers).Include(x => x.Stories).ThenInclude(x => x.Votes).ToListAsync();
        }

        public async Task<PlanningRoom?> GetByIdAsync(Guid id)
        {
            return await dbContext.PlanningRooms.Include(x => x.EstimationSystem).Include(x => x.PlanningRoomUsers).Include(x => x.Stories).ThenInclude(x => x.Votes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PlanningRoom?> UpdateAsync(Guid id, PlanningRoom planningRoom)
        {
            var existingPlanningRoom = await dbContext.PlanningRooms.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPlanningRoom == null)
            {
                return null;
            }

            existingPlanningRoom.Name = planningRoom.Name;
            existingPlanningRoom.EstimationSystemId = planningRoom.EstimationSystemId;
            existingPlanningRoom.AnyOneCanRevealCards = planningRoom.AnyOneCanRevealCards;
            existingPlanningRoom.EveryoneIsAllowedToManageStories = planningRoom.EveryoneIsAllowedToManageStories;
            existingPlanningRoom.AutoRevealCards = planningRoom.AutoRevealCards;
            existingPlanningRoom.EnableAnimation = planningRoom.EnableAnimation;
            existingPlanningRoom.ShowTimer = planningRoom.ShowTimer;
            existingPlanningRoom.IsActive = planningRoom.IsActive;
            existingPlanningRoom.CreatedTime = planningRoom.CreatedTime;
            existingPlanningRoom.LastUpdatedTime = planningRoom.LastUpdatedTime;

            await dbContext.SaveChangesAsync();
            return existingPlanningRoom;
        }
    }
}

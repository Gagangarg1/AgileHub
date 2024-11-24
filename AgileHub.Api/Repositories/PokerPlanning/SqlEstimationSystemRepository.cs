using AgileHub.Api.Data;
using AgileHub.Api.Models.Domain.PokerPlanning;
using Microsoft.EntityFrameworkCore;

namespace AgileHub.Api.Repositories.PokerPlanning
{
    public class SqlEstimationSystemRepository : IEstimationSystemRepository
    {
        private readonly AgileHubDbContext dbContext;

        public SqlEstimationSystemRepository(AgileHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<EstimationSystem> CreateAsync(EstimationSystem estimationSystem)
        {
            await dbContext.EstimationSystems.AddAsync(estimationSystem);
            await dbContext.SaveChangesAsync();
            return estimationSystem;
        }

        public async Task<EstimationSystem?> DeleteAsync(Guid id)
        {
            var estimationSystem = await dbContext.EstimationSystems.FirstOrDefaultAsync(x =>
                x.Id == id
            );
            if (estimationSystem == null)
            {
                return null;
            }

            dbContext.Remove(estimationSystem);
            await dbContext.SaveChangesAsync();
            return estimationSystem;
        }

        public async Task<List<EstimationSystem>> GetAllAsync()
        {
            return await dbContext.EstimationSystems.ToListAsync();
        }

        public async Task<EstimationSystem?> GetByIdAsync(Guid id)
        {
            return await dbContext.EstimationSystems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EstimationSystem?> UpdateAsync(Guid id, EstimationSystem estimationSystem)
        {
            var existingEstimationSystem = await dbContext.EstimationSystems.FirstOrDefaultAsync(
                x => x.Id == id
            );
            if (existingEstimationSystem == null)
            {
                return null;
            }
            existingEstimationSystem.Name = estimationSystem.Name;
            existingEstimationSystem.Values = estimationSystem.Values;

            await dbContext.SaveChangesAsync();
            return existingEstimationSystem;
        }
    }
}

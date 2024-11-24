using AgileHub.Api.Models.Domain;
using AgileHub.Api.Models.Domain.PokerPlanning;
using AgileHub.Api.Models.Domain.SprintRetro;
using Microsoft.EntityFrameworkCore;

namespace AgileHub.Api.Data
{
    public class AgileHubDbContext : DbContext
    {
        public AgileHubDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<PlanningRoom> PlanningRooms { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<EstimationSystem> EstimationSystems { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<RetroBoard> RetroBoards { get; set; }
        public DbSet<BoardColumn> BoardColumns { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var estimationSystems = new List<EstimationSystem>
            {
                new() {
                    Id = Guid.Parse("37005290-7729-4dd9-a3ec-22047d5ba636"),
                    Name = "Scrum",
                    Values = ["1/2","1","2","3","5","8","13","20","40","100","Coffee"],
                },
                new() {
                    Id = Guid.Parse("69d1b033-099e-41e9-8e13-2ddeb98a4095"),
                    Name = "Fibonacci",
                    Values = ["1","3","5","8","13","21", "34", "Coffee"],
                },
                new() {
                    Id = Guid.Parse("1a947dcb-463d-43a3-868e-ca1f9b65461f"),
                    Name = "Sequential",
                    Values = ["1","2","3","4","5","6","7","8","9","10","11","12","13","Coffee"],
                },
                new() {
                    Id = Guid.Parse("a4721373-cc8f-43c0-81a6-60676d2c024c"),
                    Name = "T-Shirt",
                    Values = ["XS","S","M","L","XL","XXL","XXXL","Coffeee"],
                }
            };

            modelBuilder.Entity<EstimationSystem>().HasData(estimationSystems);
        }
    }
}

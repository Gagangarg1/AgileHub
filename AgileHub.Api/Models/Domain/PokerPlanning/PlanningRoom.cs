using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgileHub.Api.Models.Domain.PokerPlanning
{
    public class PlanningRoom
    {
        public PlanningRoom()
        {
            Stories = [];
            PlanningRoomUsers = [];
        }

        [Key]
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(EstimationSystem))]
        public Guid EstimationSystemId { get; set; }
        public EstimationSystem EstimationSystem { get; set; }
        public bool AnyOneCanRevealCards { get; set; }
        public bool EveryoneIsAllowedToManageStories { get; set; }
        public bool AutoRevealCards { get; set; }
        public bool EnableAnimation { get; set; }
        public bool ShowTimer { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
        public ICollection<User> PlanningRoomUsers { get; set; }
        public ICollection<Story> Stories { get; set; }
    }
}

namespace AgileHub.Api.Models.DTO.PokerPlanning
{
    public class PlanningRoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EstimationSystemDto EstimationSystem { get; set; }
        public bool AnyOneCanRevealCards { get; set; }
        public bool EveryoneIsAllowedToManageStories { get; set; }
        public bool AutoRevealCards { get; set; }
        public bool EnableAnimation { get; set; }
        public bool ShowTimer { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
        public ICollection<UserDto> PlanningRoomUsers { get; set; }
        public ICollection<StoryDto> Stories { get; set; }
    }
}

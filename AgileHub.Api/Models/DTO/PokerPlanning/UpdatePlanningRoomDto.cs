namespace AgileHub.Api.Models.DTO.PokerPlanning
{
    public class UpdatePlanningRoomDto
    {
        public string Name { get; set; }
        public Guid EstimationSystemId { get; set; }
        public bool AnyOneCanRevealCards { get; set; }
        public bool EveryoneIsAllowedToManageStories { get; set; }
        public bool AutoRevealCards { get; set; }
        public bool EnableAnimation { get; set; }
        public bool ShowTimer { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}

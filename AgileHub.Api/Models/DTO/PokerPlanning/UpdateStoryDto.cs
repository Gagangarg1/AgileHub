namespace AgileHub.Api.Models.DTO.PokerPlanning
{
    public class UpdateStoryDto
    {
        public string Title { get; set; }
        public string JiraId { get; set; }
        public Guid PlanningRoomId { get; set; }
    }
}

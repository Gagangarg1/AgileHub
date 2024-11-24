namespace AgileHub.Api.Models.DTO.PokerPlanning
{
    public class StoryDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string JiraId { get; set; }
        public Guid PlanningRoomId { get; set; }
        public ICollection<VoteDto> Votes { get; set; }
    }
}

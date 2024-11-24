namespace AgileHub.Api.Models.DTO.PokerPlanning
{
    public class VoteDto
    {
        public Guid Id { get; set; }
        public int StoryPoint { get; set; }
        public UserDto User { get; set; }
    }
}

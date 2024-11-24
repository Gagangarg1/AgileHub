using System.ComponentModel.DataAnnotations;

namespace AgileHub.Api.Models.DTO.PokerPlanning
{
    public class CreateVoteDto
    {
        [Required]
        public int StoryPoint { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid StoryId { get; set; }
    }
}

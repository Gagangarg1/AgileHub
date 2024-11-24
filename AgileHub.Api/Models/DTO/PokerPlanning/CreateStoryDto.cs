using System.ComponentModel.DataAnnotations;

namespace AgileHub.Api.Models.DTO.PokerPlanning
{
    public class CreateStoryDto
    {
        [Required]
        public string Title { get; set; }
        public string JiraId { get; set; }

        [Required]
        public Guid PlanningRoomId { get; set; }
    }
}

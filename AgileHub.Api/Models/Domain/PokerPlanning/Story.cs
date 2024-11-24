using System.ComponentModel.DataAnnotations;

namespace AgileHub.Api.Models.Domain.PokerPlanning
{
    public class Story
    {
        public Story()
        {
            Votes = [];
        }

        [Key]
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string JiraId { get; set; }
        public Guid PlanningRoomId { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}

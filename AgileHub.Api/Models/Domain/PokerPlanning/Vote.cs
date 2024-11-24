using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgileHub.Api.Models.Domain.PokerPlanning
{
    public class Vote
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public int StoryPoint { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Story))]
        public Guid StoryId { get; set; }
        public Story Story { get; set; }
    }
}

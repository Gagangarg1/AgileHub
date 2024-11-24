using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgileHub.Api.Models.Domain
{
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [ForeignKey(nameof(Avatar))]
        public Guid? AvatarId { get; set; }
        public Avatar? Avatar { get; set; }
        public Guid? PlanningRoomId { get; set; }
        public Guid? RetroBoardId { get; set; }
    }
}

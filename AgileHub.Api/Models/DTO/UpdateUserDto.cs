using System.ComponentModel.DataAnnotations;

namespace AgileHub.Api.Models.DTO
{
    public class UpdateUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Guid? AvatarId { get; set; }
        public Guid? PlanningRoomId { get; set; }
        public Guid? RetroBoardId { get; set; }
    }
}

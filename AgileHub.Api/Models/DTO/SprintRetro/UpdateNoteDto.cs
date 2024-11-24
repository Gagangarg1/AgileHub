using System.ComponentModel.DataAnnotations;

namespace AgileHub.Api.Models.DTO.SprintRetro
{
    public class UpdateNoteDto
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid BoardColumnId { get; set; }
    }
}

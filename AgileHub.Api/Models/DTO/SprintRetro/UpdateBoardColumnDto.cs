using System.ComponentModel.DataAnnotations;

namespace AgileHub.Api.Models.DTO.SprintRetro
{
    public class UpdateBoardColumnDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid RetroBoardId { get; set; }
    }
}

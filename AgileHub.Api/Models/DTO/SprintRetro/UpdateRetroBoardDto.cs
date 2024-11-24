using System.ComponentModel.DataAnnotations;

namespace AgileHub.Api.Models.DTO.SprintRetro
{
    public class UpdateRetroBoardDto
    {
        [Required]
        public string Name { get; set; }
    }
}

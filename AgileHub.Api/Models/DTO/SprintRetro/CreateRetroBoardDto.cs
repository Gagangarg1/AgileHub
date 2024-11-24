using System.ComponentModel.DataAnnotations;

namespace AgileHub.Api.Models.DTO.SprintRetro
{
    public class CreateRetroBoardDto
    {
        [Required]
        public string Name { get; set; }
    }
}

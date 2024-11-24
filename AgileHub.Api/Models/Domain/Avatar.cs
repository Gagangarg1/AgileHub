using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgileHub.Api.Models.Domain
{
    public class Avatar
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extention { get; set; }
        public string Location { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}

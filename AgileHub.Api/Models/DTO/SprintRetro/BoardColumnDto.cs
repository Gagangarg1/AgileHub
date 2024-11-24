using AgileHub.Api.Models.Domain.SprintRetro;

namespace AgileHub.Api.Models.DTO.SprintRetro
{
    public class BoardColumnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}

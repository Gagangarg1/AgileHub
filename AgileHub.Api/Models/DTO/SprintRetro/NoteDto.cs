using AgileHub.Api.Models.Domain.SprintRetro;

namespace AgileHub.Api.Models.DTO.SprintRetro
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public UserInfoDto User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

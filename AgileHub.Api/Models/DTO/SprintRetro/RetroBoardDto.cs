namespace AgileHub.Api.Models.DTO.SprintRetro
{
    public class RetroBoardDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserInfoDto> RetroBoardUsers { get; set; }
        public ICollection<BoardColumnDto> BoardColumns { get; set; }
    }
}

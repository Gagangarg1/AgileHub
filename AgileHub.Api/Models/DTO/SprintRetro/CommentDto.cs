namespace AgileHub.Api.Models.DTO.SprintRetro
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public UserInfoDto User { get; set; }
    }
}

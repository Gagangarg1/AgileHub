namespace AgileHub.Api.Models.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public AvatarDto? Avatar { get; set; }
    }
}

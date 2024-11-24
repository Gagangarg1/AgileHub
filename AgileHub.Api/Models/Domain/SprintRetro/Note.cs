namespace AgileHub.Api.Models.Domain.SprintRetro
{
    public class Note
    {
        public Note()
        {
            Comments = [];
        }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid BoardColumnId { get; set; }
        public Guid UserId { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

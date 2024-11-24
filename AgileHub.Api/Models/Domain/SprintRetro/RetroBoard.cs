namespace AgileHub.Api.Models.Domain.SprintRetro
{
    public class RetroBoard
    {
        public RetroBoard()
        {
            RetroBoardUsers = [];
            BoardColumns = [];
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> RetroBoardUsers { get; set; }
        public ICollection<BoardColumn> BoardColumns { get; set; }
    }
}

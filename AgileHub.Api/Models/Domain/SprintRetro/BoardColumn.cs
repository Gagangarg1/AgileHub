namespace AgileHub.Api.Models.Domain.SprintRetro
{
    public class BoardColumn
    {
        public BoardColumn()
        {
            Notes = [];
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid RetroBoardId { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}

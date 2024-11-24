﻿namespace AgileHub.Api.Models.Domain.SprintRetro
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid NoteId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}

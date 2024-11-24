﻿using System.ComponentModel.DataAnnotations;

namespace AgileHub.Api.Models.DTO.SprintRetro
{
    public class CreateCommentDto
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid NoteId { get; set; }
    }
}
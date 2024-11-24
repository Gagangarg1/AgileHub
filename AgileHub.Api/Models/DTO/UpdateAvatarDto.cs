﻿using System.ComponentModel.DataAnnotations;

namespace AgileHub.Api.Models.DTO
{
    public class UpdateAvatarDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Extention { get; set; }

        [Required]
        public string Location { get; set; }
    }
}

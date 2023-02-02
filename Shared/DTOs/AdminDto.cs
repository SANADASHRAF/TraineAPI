﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record AdminWithoutchiledForManipulationDto
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string AdminDegree { get; set; } = string.Empty;
    }
    public record AdminDto(int Id, string? Name, string? Password, string? Phone, string? Email, string? AdminDegree);

    public record AdminCreationDto : AdminWithoutchiledForManipulationDto;

    public record AdminUpdateDto : AdminWithoutchiledForManipulationDto;
}

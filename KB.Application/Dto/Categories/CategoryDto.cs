using Comm100.Constants;
using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Application.Dto.Categories
{
    public class CategoryDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(StringLength.MaxNameLength)]
        public string Name { get; set; }

        public CategoryStateEnum State { get; set; }

    }
}

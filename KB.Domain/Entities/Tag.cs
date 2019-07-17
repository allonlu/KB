namespace KB.Domain.Entities
{
    using KB.Infrastructure.Constant;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Tag : IEntity
    {
 
        [Key]
        public int Id { get;  set; }

        [Required]
        [MaxLength(Constant.MaxNameLength)]
        public string Name { get; set; }

    }
}

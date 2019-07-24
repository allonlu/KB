using KB.Infrastructure.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Application.Dto.Tags
{
    public class QueryTagInput
    {
        [MaxLength(Constant.MaxNameLength)]
        public string Name { get; set; }
    }
}

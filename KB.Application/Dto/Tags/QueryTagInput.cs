
using Comm100.Constants;
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
        [MaxLength(StringLength.MaxNameLength)]
        public string Name { get; set; }
    }
}

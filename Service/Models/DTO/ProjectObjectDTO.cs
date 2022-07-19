using Service.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.DTO
{
    public class ProjectObjectDTO : ProjectDTO
    {
        public string ParentKey { get; set; }
    }
}

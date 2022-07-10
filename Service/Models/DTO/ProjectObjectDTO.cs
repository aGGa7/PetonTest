using Service.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.DTO
{
    public class ProjectObjectDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Executor Executor { get; set; }
        public List<ProjectObjectDTO> Objects { get; set; }
       // public string ParentCode { get; set; }
    }
}

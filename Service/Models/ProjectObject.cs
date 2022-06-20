using Service.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class ProjectObject
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Executor  Executor { get; set; }
        public string ParentCode { get; set; }
        public string ProjectSipher { get; set; }
        public Project Project { get; set; }
    }
}

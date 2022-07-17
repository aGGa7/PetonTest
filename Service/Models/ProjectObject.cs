using Service.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string ParentObjectCode { get; set; }
        public virtual List<ProjectObject> Objects { get; set; }
        public string ProjectСipher { get; set; }
        public virtual Project Project { get; set; }
    }
}

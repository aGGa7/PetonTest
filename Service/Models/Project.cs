using Service.Models.Enums;
using System.Collections.Generic;

namespace Service.Models
{
    public class Project
    {
        public string Сipher { get; set; }
        public string Name { get; set; }
        public Executor Executor { get; set; }
        public virtual List<ProjectObject> Objects { get; set; } 
    }
}

using Service.Models.Enums;
using System.Collections.Generic;

namespace Service.Models
{
    public class Project
    {
        public string Sipher { get; set; }
        public string Name { get; set; }
        public Executor Executor { get; set; }
        public List<ProjectObject> Objects { get; set; } = new();
    }
}

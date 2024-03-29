﻿using Service.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Models
{
    public class Project
    {
        public string Cipher { get; set; }
        public string Name { get; set; }
        public Executor Executor { get; set; }
        public virtual List<ProjectObject> Objects { get; set; } 
    }
}

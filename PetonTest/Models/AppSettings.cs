using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetonTest.Models
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set;}
    }

    public class ConnectionStrings
    {
        public string PetonDatabaseConnection { get; set; }
    }
}

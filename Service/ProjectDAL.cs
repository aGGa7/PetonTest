using Service.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProjectDAL
    {
        private ProjectDataContext _dataContext { get; }
        public ProjectDAL(ProjectDataContext context)
        {
            this._dataContext = context;
        }


    }
}

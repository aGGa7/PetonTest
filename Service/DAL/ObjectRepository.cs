using Service.Context;
using Service.Models;
using Service.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DAL
{
    public class ObjectRepository
    {
        private DataContext _dataContext { get; }
        public ObjectRepository(DataContext context)
        {
            this._dataContext = context;
        }

        public IEnumerable<ProjectObjectDTO> GetObjects(IEnumerable<string> codes)
        {
            return _dataContext.Objects.Where(o => codes.Contains(o.Code))
                .Select(Map)
                .ToArray();
        }

        private ProjectObjectDTO Map (ProjectObject model)
        {
            return new ProjectObjectDTO()
            {
                Code = model.Code,
                ParentCode = model.ParentCode,
                Executor = model.Executor,
                Name = model.Name,
                Project = model.Project
            };
        }
    }
}

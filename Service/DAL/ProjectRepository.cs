using Service.Context;
using Service.Models;
using Service.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProjectRepository
    {
        private DataContext _dataContext { get; }
        public ProjectRepository(DataContext context)
        {
            this._dataContext = context;
        }

        public IEnumerable<ProjectDTO> GetProjects (IEnumerable<string> ciphers)
        {
            return _dataContext.Projects.Where(p => ciphers.Contains(p.Сipher))
                                        .Select(Map)
                                        .ToArray();
        }

        private ProjectDTO Map (Project model)
        {
            return new ProjectDTO()
            {
                Cipher = model.Сipher,
                Executor = model.Executor,
                Name = model.Name,
                Objects = model.Objects
            };
        }
    }
}

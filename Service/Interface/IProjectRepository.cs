using Service.Models;
using Service.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Service.Interface
{
    public interface IProjectRepository
    {
        ProjectDTO[] GetProjects(Expression<Func<Project, bool>> filter = null, Func<IQueryable<Project>, IOrderedQueryable<Project>> orderBy = null,
          string includeProperties = "");
        string CreateProject(ProjectDTO project);
        bool DeleteProject(string cipher);
        bool UpdateProject(ProjectDTO project);
    }
}

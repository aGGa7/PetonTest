using Microsoft.EntityFrameworkCore;
using Service.Context;
using Service.Interface;
using Service.Models;
using Service.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProjectRepository : IProjectRepository
    {
        private DataContext _dataContext { get; }
        public ProjectRepository(DataContext context)
        {
            this._dataContext = context;
        }

        public ProjectDTO[] GetProjects(Expression<Func<Project, bool>> filter = null, Func<IQueryable<Project>, IOrderedQueryable<Project>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<Project> query = _dataContext.Projects.AsNoTracking()
                                                             .Where(e => !(e is ProjectObject));
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var propery in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(propery);
            }
            if (orderBy != null)
            {
                try
                {
                    return orderBy(query).Select(Map).ToArray();
                }
                catch
                {
                    throw;
                }

            }
            else
            {
                try
                {
                    return query.Select(Map).ToArray();
                }
                catch
                {
                    throw;
                }
            }
        }
        public string CreateProject(ProjectDTO project)
        {
            try
            {
                project.Cipher = Guid.NewGuid().ToString();
                _dataContext.Projects.Add(Map(project));
                _dataContext.SaveChanges();
            }
            catch
            {
                return Guid.Empty.ToString();
            }

            return project.Cipher;
        }

        public bool DeleteProject(string cipher)
        {

            var project = _dataContext.Projects.FirstOrDefault(p => p.Cipher == cipher);
            if (project == null)
            {
                return false;
            }
            try
            {
                _dataContext.Projects.Remove(project);
                _dataContext.SaveChanges();

            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool UpdateProject(ProjectDTO project)
        {
            var udateproject = _dataContext.Projects.FirstOrDefault(p => p.Cipher == project.Cipher);
            if (udateproject == null)
            {
                return false;
            }
            try
            {
                udateproject.Executor = project.Executor;
                udateproject.Name = project.Name;
                udateproject.Objects = project.Objects.Select(Map).ToList();
                _dataContext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        private ProjectDTO Map(Project model)
        {
            return new ProjectDTO()
            {
                Cipher = model.Cipher,
                Executor = model.Executor,
                Name = model.Name,
                Objects = model.Objects?.Select(Map).ToList()
            };
        }
        private Project Map(ProjectDTO model)
        {
            return new Project()
            {
                Cipher = model.Cipher,
                Executor = model.Executor,
                Name = model.Name,
            };
        }
        private ProjectObjectDTO Map(ProjectObject model)
        {
            return new ProjectObjectDTO()
            {
                ParentKey = model.ParentKey,
                Cipher = model.Cipher,
                Executor = model.Executor,
                Name = model.Name
            };
        }
        private ProjectObject Map(ProjectObjectDTO model)
        {
            return new ProjectObject()
            {
                Cipher = model.Cipher,
                Executor = model.Executor,
                Name = model.Name
            };
        }
    }
}

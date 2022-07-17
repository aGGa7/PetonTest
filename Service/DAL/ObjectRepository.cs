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

namespace Service.DAL
{
    public class ObjectRepository : IObjectRepository
    {
        private DataContext _dataContext { get; }
        public ObjectRepository(DataContext context)
        {
            this._dataContext = context;
        }

        public ProjectObjectDTO[] GetObjects(Expression<Func<ProjectObject, bool>> filter = null, Func<IQueryable<ProjectObject>, IOrderedQueryable<ProjectObject>> orderBy = null,
        string includeProperties = "")
        {
            IQueryable<ProjectObject> query = _dataContext.Objects.AsNoTracking();
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
                return orderBy(query).Select(Map).ToArray();
            }
            else
            {
                return query.Select(Map).ToArray();
            }

        }

        public string CreateObject (ProjectObjectDTO objectModel)
        {
            objectModel.Code = Guid.NewGuid().ToString();
            try
            {
                _dataContext.Objects.Add(Map(objectModel));
                _dataContext.SaveChanges();
            }
            catch
            {
                return Guid.Empty.ToString();
            }
            return objectModel.Code;
        }

        public bool DeleteObject (string code)
        {
            var projectObject = _dataContext.Objects.FirstOrDefault(o => o.Code == code);
            if(projectObject == null)
            {
                return false;
            }
            try
            {
                _dataContext.Objects.Remove(projectObject);
                _dataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateObject (ProjectObjectDTO updateObject)
        {
            var projectObject = _dataContext.Objects.FirstOrDefault(o => o.Code == updateObject.Code);
            if (projectObject == null)
            {
                return false;
            }
            
            try
            {
                projectObject.Name = updateObject.Name;
                projectObject.Executor = updateObject.Executor;
                projectObject.ParentObjectCode = updateObject.ParentObjectCode;
                _dataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private ProjectObjectDTO Map (ProjectObject model)
        {
            return new ProjectObjectDTO()
            {
                Code = model.Code,
                Executor = model.Executor,
                Name = model.Name,
                ParentObjectCode = model.ParentObjectCode,
                ProjectСipher = model.ProjectСipher
            };
        }

        private ProjectObject Map(ProjectObjectDTO model)
        {
            return new ProjectObject()
            {
                Code = model.Code,
                Executor = model.Executor,
                Name = model.Name,
                ParentObjectCode = model.ParentObjectCode,
                ProjectСipher = model.ProjectСipher
            };
        }
    }
}

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

        public IEnumerable<ProjectObjectDTO> GetObjects(Expression<Func<ProjectObject, bool>> filter = null, Func<IQueryable<ProjectObject>, IOrderedQueryable<ProjectObject>> orderBy = null,
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

        }

        private ProjectObjectDTO Map (ProjectObject model)
        {
            return new ProjectObjectDTO()
            {
                Code = model.Code,
                Executor = model.Executor,
                Name = model.Name,
            };
        }
    }
}

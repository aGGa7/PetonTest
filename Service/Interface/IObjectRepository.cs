using Service.Models;
using Service.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Service.Interface
{
    public interface IObjectRepository
    {
        IEnumerable<ProjectObjectDTO> GetObjects(Expression<Func<ProjectObject, bool>> filter = null, Func<IQueryable<ProjectObject>, IOrderedQueryable<ProjectObject>> orderBy = null,
        string includeProperties = "");

    }
}

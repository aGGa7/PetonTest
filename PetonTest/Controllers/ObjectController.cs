using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetonTest.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ObjectController : ControllerBase
    {
        private IObjectRepository _repository { get; }
        public ObjectController(IObjectRepository repository)
        {
            this._repository = repository;
        }

        [HttpPost]
        public ActionResult<IEnumerable<ProjectObjectDTO>> GetAllObjects()
        {
            var projects = _repository.();
            return projects;
        }
    }
}

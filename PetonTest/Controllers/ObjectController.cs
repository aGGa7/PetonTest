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
            var projects = _repository.GetObjects();
            return projects;
        }

        [HttpPost]
        public ActionResult<string> CreateObject(ProjectObjectDTO newObject)
        {
            var code = _repository.CreateObject(newObject);
            if (code.Equals(Guid.Empty))
            {
                return BadRequest();
            }
            return code;
        }

        [HttpDelete]
        public ActionResult<bool> DeleteObject(string code)
        {
            var result = _repository.DeleteObject(code);
            return result;
        }

        [HttpPut]
        public ActionResult<bool> UpdateObject(ProjectObjectDTO updateObject)
        {
            var result = _repository.UpdateObject(updateObject);
            return result;
        }
    }
}

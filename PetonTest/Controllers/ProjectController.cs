using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetonTest.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProjectController : ControllerBase
    {
        private IProjectRepository _repository { get; }

        public ProjectController(IProjectRepository repository)
        {
            this._repository = repository;
        }

        [HttpPost]
        public ActionResult<IEnumerable<ProjectDTO>> GetAllProjects()
        {
            var projects = _repository.GetProjects(null, null, nameof(ProjectDTO.Objects));
            return projects;
        }

        [HttpPost]
        public ActionResult<IEnumerable<ProjectDTO>> GetProjects(string[] ciphers)
        {
            var projects = _repository.GetProjects(x => ciphers.Contains(x.Cipher));
            if(projects?.Any() ?? false)
            {
                return NotFound();
            }
            return projects;
        }

        [HttpPost]
        public ActionResult<string> CreateProject (ProjectDTO project)
        {
            var cipher = _repository.CreateProject(project);
            if(cipher.Equals(Guid.Empty))
            {
                return BadRequest();
            }
            return cipher;
        }

        [HttpDelete]
        public ActionResult<bool> DeleteProject (string cipher)
        {
            var result = _repository.DeleteProject(cipher);
            return result;
        }

        [HttpPut]
        public ActionResult<bool> UpdateProject (ProjectDTO project)
        {
            var result = _repository.UpdateProject(project);
            return result;
        }
    }
}

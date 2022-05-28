using business_logic.services.interfaces;
using data.models.entities;
using data.models.viewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }


        [HttpGet]
        public ActionResult<ProjectViewModel> GetProjects()
        {
            return _projectService.GetProjects();
        }

        [HttpPost]
        public ActionResult<ProjectViewModel> Create(Project project)
        {
            return _projectService.Create(project);
        }
        [HttpPut("{id}")]
        public ActionResult<ProjectViewModel> Update(Guid id, Project project)
        {

            return _projectService.Update(project, id);
        }

      
        [HttpGet("{id}")]
        public ActionResult<ProjectViewModel> GetProjectById(Guid id)
        {
            return _projectService.GetProjectById(id);
        }

        [HttpDelete("{id}")]
        public ActionResult<ProjectViewModel> Delete(Guid id)
        {

            return _projectService.Delete(id);
        }

  

    }
}

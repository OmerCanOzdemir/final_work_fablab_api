using business_logic.services.interfaces;
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










    }
}

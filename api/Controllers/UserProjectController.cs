using business_logic.services.interfaces;
using data.models.viewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/UserProject")]
    [ApiController]
    public class UserProjectController : ControllerBase
    {
        private readonly IUserProjectService _userProjectService;

        public UserProjectController(IUserProjectService userProjectService)
        {
            _userProjectService = userProjectService;
        }

        [HttpPost("participate/{userId}/{projectId}")]
        public ActionResult<UserProjectViewModel> Participate(string userId,Guid projectId)
        {
            return _userProjectService.Participate(userId,projectId);
        }

        [HttpPost("unParticipate/{id}")]
        public ActionResult<UserProjectViewModel> UnParticipate(Guid id)
        {
            return _userProjectService.UnParticipate(id);
        }
    }
}

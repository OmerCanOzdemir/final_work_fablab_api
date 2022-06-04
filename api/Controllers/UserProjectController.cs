using business_logic.services.interfaces;
using data.models.DTO;
using data.models.viewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/UserProject")]
    [EnableCors("ReactApp")]
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
        [HttpPost("giveScore/{id}")]
        public ActionResult<UserProjectViewModel> GiveScore(Guid id,ScoreDTO score)
        {
          
            return _userProjectService.GiveScore(id,score.Score);
        }

    }
}

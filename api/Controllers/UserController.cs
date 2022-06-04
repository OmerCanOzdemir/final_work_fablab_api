using business_logic.services.interfaces;
using data.models.entities;
using data.models.viewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/User")]
    [EnableCors("ReactApp")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpGet]
        public ActionResult<UserViewModel> GetUsers()
        {
            return _userService.GetUsers();
        }

        [HttpPost]
        public ActionResult<UserViewModel> Create(User user)
        {
            return _userService.Create(user);
        }
        [HttpPut("{id}")]
        public ActionResult<UserViewModel> Update(string id, User user)
        {

            return _userService.Update(user,id);
        }

        [HttpGet("{email}")]
        public ActionResult<UserViewModel> GetUserByEmailName(string email)
        {

            return _userService.GetUserByEmail(email);
        }
        [HttpGet("byId/{id}")]
        public ActionResult<UserViewModel> GetEducationById(string id)
        {
            return _userService.GetUserById(id);
        }
        [HttpPost("invite")]
        public ActionResult<InvitationViewModel> SendInvitation(Invitation invitation)
        {
            return _userService.SendInvitation(invitation);
        }

        [HttpPost("acceptInvitation/{id}")]
        public ActionResult<InvitationViewModel> AcceptInvitation(Guid id)
        {
            return _userService.AcceptInvitation(id);
        }

        [HttpGet("/test")]
        public ActionResult<string> test()
        {
            return Ok("test");
        }
        
    }
}

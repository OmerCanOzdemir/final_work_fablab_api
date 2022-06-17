using business_logic.services.interfaces;
using data.models.entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [Route("api/Category")]
    [EnableCors("ReactApp")]
    [ApiController]
    public class EmailController: ControllerBase
    {

        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }


        public ActionResult<bool> SendEmail(EmailBody email)
        {
            return _emailService.SendEmail(email);
        }
    }
}

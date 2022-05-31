using business_logic.services.interfaces;
using data.models.entities;
using data.models.viewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Education")]
    [EnableCors("ReactApp")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }



        [HttpGet]
        public ActionResult<EducationViewModel> GetCategories()
        {
            return _educationService.GetEducations();
        }

        [HttpPost]
        public ActionResult<EducationViewModel> Create(Education education)
        {
            return _educationService.Create(education);
        }
        [HttpPut("{id}")]
        public ActionResult<EducationViewModel> Update(Guid id, Education education)
        {

            return _educationService.Update(id, education);
        }

        [HttpGet("{name}")]
        public ActionResult<EducationViewModel> GetEducationByName(string name)
        {

            return _educationService.GetEducationByName(name);
        }
        [HttpGet("byId/{id}")]
        public ActionResult<EducationViewModel> GetEducationById(Guid id)
        {

            return _educationService.GetEducationById(id);
        }
    }
}

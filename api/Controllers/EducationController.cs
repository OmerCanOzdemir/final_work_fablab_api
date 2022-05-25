using business_logic.services.interfaces;
using data.models.entities;
using data.models.viewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Education")]
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
        public ActionResult<EducationViewModel> Create(Education category)
        {
            return _educationService.Create(category);
        }
        [HttpPut("{id}")]
        public ActionResult<EducationViewModel> Update(Guid id, Education category)
        {

            return _educationService.Update(id, category);
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

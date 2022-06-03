using business_logic.services.interfaces;
using data.models.viewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Statistics")]
    [EnableCors("ReactApp")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {


        private readonly IStatisticsDataService _statisticsDataService;

        public StatisticsController(IStatisticsDataService statisticsDataService)
        {
            _statisticsDataService = statisticsDataService;
        }

        [HttpGet]
        public ActionResult<StatisticsDataViewModel> GetStatisticsData()
        {
            return _statisticsDataService.GetStatisticsData();
        }
    }
}

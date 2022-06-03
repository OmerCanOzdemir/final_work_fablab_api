using business_logic.services.interfaces;
using data.models.viewModels;
using data.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_logic.services
{
    public class StatisticsDataService : IStatisticsDataService
    {
        private readonly IStatisticsDataRepository _statisticsDataRepository;

        public StatisticsDataService(IStatisticsDataRepository statisticsDataRepository)
        {
            _statisticsDataRepository = statisticsDataRepository;
        }

        public StatisticsDataViewModel GetStatisticsData()
        {
            return _statisticsDataRepository.GetStatisticsData().Result;
        }
    }
}

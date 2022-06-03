using data.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_logic.services.interfaces
{
    public interface IStatisticsDataService
    {
        StatisticsDataViewModel GetStatisticsData();
    }
}

using data.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositories.interfaces
{
    public interface IStatisticsDataRepository
    {
        Task<StatisticsDataViewModel> GetStatisticsData();
    }
}

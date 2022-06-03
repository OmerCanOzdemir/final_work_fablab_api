using data.context;
using data.models.viewModels;
using data.repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace data.repositories
{
    public class StatisticsDataRepository : BaseRepository,IStatisticsDataRepository
    {
        private readonly Context _context;

        public StatisticsDataRepository(Context context):base(context)
        {
            _context = context;
        }
        public async Task<StatisticsDataViewModel> GetStatisticsData()
        {
           
                try
                {
                    var users_created_by_months =  _context.Users.Where(u => u.User_Created_Time.Value.Year.Equals(DateTime.Now.Year)).GroupBy(u => u.User_Created_Time.Value.Month).OrderBy(g => g.Key).Select(g => Tuple.Create(g.Key, g.Count()));
                    var user_interests = _context.UserCategories.Include(e => e.Category).GroupBy(c => c.Category.Name).OrderBy(g => g.Key).Select(g => Tuple.Create(g.Key, g.Count()));
                    var user_educations = _context.Users.Include(e => e.Education).GroupBy(e => e.Education.Name).OrderBy(g => g.Key).Select(g => Tuple.Create(g.Key, g.Count()));
                    var projects_created_by_months = _context.Project.Where(p => p.Created_Date.Value.Year.Equals(DateTime.Now.Year)).GroupBy(p => p.Created_Date.Value.Month).OrderBy(g => g.Key).Select(g => Tuple.Create(g.Key, g.Count()));
                    var projects_categories =_context.Project.Include(p => p.Category).GroupBy(c => c.Category.Name).OrderBy(g => g.Key).Select(g => Tuple.Create(g.Key, g.Count()));



                    return new StatisticsDataViewModel(users_created_by_months,user_interests,user_educations,projects_created_by_months,projects_categories,null,HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return new StatisticsDataViewModel(null,null,null,null,null,ex.InnerException.Message,HttpStatusCode.InternalServerError);
                }
            
        }
    }
}

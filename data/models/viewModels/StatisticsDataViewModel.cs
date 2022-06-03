using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace data.models.viewModels
{
    public class StatisticsDataViewModel
    {
        
        public IQueryable<Tuple<int,int>> UserCreatedMonths { get; set; }
        public IQueryable<Tuple<string, int>> UserInterests { get; set; }
        public IQueryable<Tuple<string, int>> UserEducation { get; set; }
        public IQueryable<Tuple<int, int>> ProjectsCreatedMonths { get; set; }
        public IQueryable<Tuple<string, int>> ProjectCategories { get; set; }

        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public StatisticsDataViewModel(IQueryable<Tuple<int, int>> userCreatedMonths, IQueryable<Tuple<string, int>> userInterests, IQueryable<Tuple<string, int>> userEducation, IQueryable<Tuple<int, int>> projectsCreatedMonths, IQueryable<Tuple<string, int>> projectCategories, string errorMessage, HttpStatusCode statusCode)
        {
            UserCreatedMonths = userCreatedMonths;
            UserInterests = userInterests;
            UserEducation = userEducation;
            ProjectsCreatedMonths = projectsCreatedMonths;
            ProjectCategories = projectCategories;
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
    }
}

using data.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace data.models.viewModels
{
    public class EducationViewModel
    {
        public EducationViewModel()
        {
        }

        public EducationViewModel(List<Education>? educations, HttpStatusCode statusCode, string? errorMessage)
        {
            Educations = educations;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public EducationViewModel(HttpStatusCode statusCode, Education? education, string? errorMessage)
        {
            Education = education;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public Education Education { get; set; }
        public List<Education>? Educations { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string? ErrorMessage { get; set; }
    }
}

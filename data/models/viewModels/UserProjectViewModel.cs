using data.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace data.models.viewModels
{
    public class UserProjectViewModel
    {
        public UserProjectViewModel()
        {

        }

        public UserProjectViewModel(ProjectUser project_User, HttpStatusCode statusCode, string? errorMessage)
        {
            ProjectUser = project_User;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public ProjectUser ProjectUser { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public string? ErrorMessage { get; set; }
    }
}

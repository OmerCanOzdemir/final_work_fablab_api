using data.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace data.models.viewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
        }

        public ProjectViewModel(List<Project>? projects, HttpStatusCode statusCode, string? errorMessage)
        {
            Projects = projects;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public ProjectViewModel(HttpStatusCode statusCode, Project? project, string? errorMessage)
        {
            Project = project;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public Project Project { get; set; }
        public List<Project>? Projects { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string? ErrorMessage { get; set; }
    }
}

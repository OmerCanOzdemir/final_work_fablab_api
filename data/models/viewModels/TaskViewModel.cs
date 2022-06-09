using data.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Task = data.models.entities.Task;

namespace data.models.viewModels
{
    public class TaskViewModel
    {
        public TaskViewModel()
        {

        }

        public TaskViewModel(Task task, HttpStatusCode statusCode, string? errorMessage)
        {
            Task = task;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public Task Task { get; set; }


        public HttpStatusCode StatusCode { get; set; }

        public string? ErrorMessage { get; set; }
    }
}

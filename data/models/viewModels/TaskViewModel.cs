using data.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaskModel = data.models.entities.TaskModel;

namespace data.models.viewModels
{
    public class TaskViewModel
    {
        public TaskViewModel()
        {

        }

        public TaskViewModel(TaskModel task, HttpStatusCode statusCode, string? errorMessage)
        {
            Task = task;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public TaskModel Task { get; set; }


        public HttpStatusCode StatusCode { get; set; }

        public string? ErrorMessage { get; set; }
    }
}

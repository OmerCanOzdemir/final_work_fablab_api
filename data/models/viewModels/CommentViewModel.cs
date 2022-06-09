using data.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace data.models.viewModels
{
    public class CommentViewModel
    {
        public CommentViewModel()
        {

        }

        public CommentViewModel(Comment comment, HttpStatusCode statusCode, string? errorMessage)
        {
            Comment = comment;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public Comment Comment { get; set; }


        public HttpStatusCode StatusCode { get; set; }

        public string? ErrorMessage { get; set; }
    }
}

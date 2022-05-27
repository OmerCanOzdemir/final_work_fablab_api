using data.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace data.models.viewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
        }

        public UserViewModel(List<User>? users, HttpStatusCode statusCode, string? errorMessage)
        {
            Users = users;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public UserViewModel(HttpStatusCode statusCode, User? user, string? errorMessage)
        {
            User = user;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public User User { get; set; }
        public List<User>? Users { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string? ErrorMessage { get; set; }
    }
}

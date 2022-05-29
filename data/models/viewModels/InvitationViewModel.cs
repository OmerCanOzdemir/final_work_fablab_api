using data.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace data.models.viewModels
{
    public class InvitationViewModel
    {
        public InvitationViewModel()
        {

        }

        public InvitationViewModel(Invitation invitation, HttpStatusCode statusCode, string? errorMessage)
        {
            Invitation = invitation;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public Invitation Invitation { get; set; }
     

        public HttpStatusCode StatusCode { get; set; }

        public string? ErrorMessage { get; set; }
    }
}

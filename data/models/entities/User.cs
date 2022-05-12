﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.models.entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public Guid Education_Id { get; set; }

        public Education Education { get; set; }

        public string Profile_Image { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Project_User> Joined_Projects { get; set; }
        public ICollection<Project> Created_Projects { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
    }

 
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.models.entities
{
    public class Invitation
    {
        [Key]
        public Guid Id { get; set; }

        public string From { get; set; }

        public Guid Project_Id { get; set; }
        public string Project_Description { get; set; }

        public string User_Id { get; set; }

    }
}

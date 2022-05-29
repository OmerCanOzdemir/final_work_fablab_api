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

        public Guid ProjectId { get; set; }
        public string ProjectDescription { get; set; }

        public string UserId { get; set; }
        public User? User { get; set; }
    }
}

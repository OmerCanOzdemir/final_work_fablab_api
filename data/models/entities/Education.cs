using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.models.entities
{
    public class Education
    {
        [Key]
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Department_Address { get; set; }


        public ICollection<User>? Users { get; set; }
    }
}

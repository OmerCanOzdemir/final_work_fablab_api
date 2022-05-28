using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.models.entities
{
    public class Project_User
    {
        [Key]
        public Guid Id { get; set; }
        public string? User_Id { get; set; }
        public Guid? Project_Id { get; set; }

        public Project? Project { get; set; }

        public User? User { get; set; }



    }
}

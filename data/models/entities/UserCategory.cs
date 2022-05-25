using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.models.entities
{
    public class UserCategory
    {

        [Key]
        public Guid Id { get; set; }
        public string User_Id{ get; set; }

        public Guid Category_Id { get; set; }

        public Category Category { get; set; }

        public User User { get; set; }
    }
}

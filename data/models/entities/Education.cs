using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.models.entities
{
    public class Education
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Department_Address { get; set; }


        public ICollection<User> Users { get; set; }
    }
}

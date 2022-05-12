using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.models.entities
{
    public class Project_User
    {
        public Guid Id { get; set; }

        public Guid User_Id { get; set; }
        public Guid Project_Id { get; set; }

    }
}

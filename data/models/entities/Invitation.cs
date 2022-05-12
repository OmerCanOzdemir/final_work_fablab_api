using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.models.entities
{
    public class Invitation
    {
        public Guid Id { get; set; }

        public string From { get; set; }

        public Guid Project_Id { get; set; }
        public string Project_Description { get; set; }

        public Guid User_Id { get; set; }

    }
}

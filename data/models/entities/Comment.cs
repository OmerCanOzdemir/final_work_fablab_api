using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.models.entities
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string? Message { get; set; }

        public string? UserId { get; set; }

        public User? User { get; set; }

        public Project? Project { get; set; }

        public Guid ProjectId { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}

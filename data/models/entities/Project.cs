using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.models.entities
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }
        public string? User_Id { get; set; }
        public User? User { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }

        public string? Description { get; set; }
        public int? Max_Users { get; set; }
        public Guid? Category_Id { get; set; }
        public Category? Category { get; set; }
        public string? Image_Url { get; set; }
        public bool IsPublic { get; set; }
        public DateTime? Created_Date { get; set; }

        public bool IsDeleted { get; set; }
        public ICollection<Project_User>? Project_Users { get; set; }


    }
}

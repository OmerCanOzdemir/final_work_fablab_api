﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.models.entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Project>? Projects { get; set; }

        public ICollection<UserCategory>? UserCategory { get; set; }
    }
}

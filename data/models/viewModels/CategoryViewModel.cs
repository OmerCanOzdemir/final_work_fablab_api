using data.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace data.models.viewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
        }

        public CategoryViewModel(List<Category>? categories, HttpStatusCode statusCode, string? errorMessage)
        {
            Categories = categories;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public CategoryViewModel(HttpStatusCode statusCode, Category? category, string? errorMessage)
        {
            Category = category;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public Category Category { get; set; }
        public List<Category>? Categories { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string? ErrorMessage { get; set; }
    }
}

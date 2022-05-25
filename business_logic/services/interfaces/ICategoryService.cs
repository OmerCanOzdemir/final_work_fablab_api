using data.models.entities;
using data.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_logic.services.interfaces
{
    public interface ICategoryService
    {
        CategoryViewModel GetCategoryByName(string name);
        CategoryViewModel Update(Guid id, Category category);
        CategoryViewModel Create(Category category);
        CategoryViewModel GetCategoryById(Guid id);
        CategoryViewModel GetCategories();
    }
}

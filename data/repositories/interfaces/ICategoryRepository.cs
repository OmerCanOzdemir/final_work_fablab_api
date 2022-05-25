using data.models.entities;
using data.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositories.interfaces
{
    public interface ICategoryRepository
    {
        Task<CategoryViewModel> GetCategoryById(Guid id);

        Task<CategoryViewModel> GetAllCategories();

        Task<CategoryViewModel> GetCategoryByName(string name);

        Task<CategoryViewModel> Create(Category category);

        Task<CategoryViewModel> Update(Category category);



    }
}

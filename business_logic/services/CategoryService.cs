using business_logic.services.interfaces;
using data.models.entities;
using data.models.viewModels;
using data.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_logic.services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository= categoryRepository;
        }
        public CategoryViewModel Create(Category category)
        {
            category.Name = category.Name.ToUpper();
            return _categoryRepository.Create(category).Result;
        }

        public CategoryViewModel GetCategories()
        {
            return _categoryRepository.GetAllCategories().Result;
        }

        public CategoryViewModel GetCategoryByName(string name)
        {
            name = name.ToUpper();
            return _categoryRepository.GetCategoryByName(name).Result;
        }

        public CategoryViewModel GetCategoryById(Guid id)
        {
            return _categoryRepository.GetCategoryById(id).Result;
        }

        public CategoryViewModel Update(Guid id, Category category)
        {
            var categoryViewModel = _categoryRepository.GetCategoryById(id).Result;

            if(categoryViewModel.Category == null)
            {
                return categoryViewModel;
            }
            var dbCategory = categoryViewModel.Category;
            dbCategory.Name = category.Name.ToUpper();
            dbCategory.Description = category.Description;
           
            return _categoryRepository.Update(dbCategory).Result;
        }
    }
}

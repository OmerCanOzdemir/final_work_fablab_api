using data.context;
using data.models.entities;
using data.models.viewModels;
using data.repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace data.repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<CategoryViewModel> Create(Category category)
        {
            using (var context = new Context(Context.Option.Options))
            {
                try
                {
                    
                    await context.Categories.AddAsync(category);
                    await context.SaveChangesAsync();
                    return new CategoryViewModel(HttpStatusCode.OK, category, null);
                }
                catch (Exception ex)
                {
                    return new CategoryViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }
            }
        }

        public async Task<CategoryViewModel> GetAllCategories()
        {
            using (var context = new Context(Context.Option.Options))
            {
                try
                {

                    var categories = await context.Categories.ToListAsync();

                    return new CategoryViewModel(categories, HttpStatusCode.OK, null);
                }
                catch (Exception ex)
                {
                    return new CategoryViewModel(null, HttpStatusCode.InternalServerError, ex.InnerException!.Message);
                }
            }

        }
    

    public async Task<CategoryViewModel> GetCategoryById(Guid id)
    {
            using (var context = new Context(Context.Option.Options))
            {
                try
                {
                    var category = await context.Categories.FirstOrDefaultAsync(c => c.Id.Equals(id));

                    if (category == null)
                    {
                        return new CategoryViewModel(HttpStatusCode.NotFound, null, null);
                    }
                    return new CategoryViewModel(HttpStatusCode.OK, category, null);
                }
                catch (Exception ex)
                {
                    return new CategoryViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }
            }
        }
    

        public async Task<CategoryViewModel> GetCategoryByName(string name)
        {
            using (var context = new Context(Context.Option.Options))
            {
                try
                {
                    var category = await context.Categories.FirstOrDefaultAsync(c => c.Name.Equals(name));


                    if (category == null)
                    {
                        return new CategoryViewModel(HttpStatusCode.NotFound, null, null);
                    }
                    return new CategoryViewModel(HttpStatusCode.OK, category, null);
                }
                catch (Exception ex)
                {
                    return new CategoryViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }

            }
        }

        public async Task<CategoryViewModel> Update(Category category)
        {
            using (var context = new Context(Context.Option.Options))
            {
                try
                {
                  
                    context.Categories.Update(category);
                    await context.SaveChangesAsync();
                    return new CategoryViewModel(HttpStatusCode.OK, category, null);
                }
                catch (Exception ex)
                {
                    return new CategoryViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }
            }
        }
    }
}

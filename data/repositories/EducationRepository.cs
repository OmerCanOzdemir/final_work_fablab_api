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
    public  class EducationRepository : BaseRepository, IEducationRepository
    {
        private readonly Context _context;
        public EducationRepository(Context context) : base(context)
        {
            _context = context;

        }
        public async Task<EducationViewModel> Create(Education education)
        {
            
                try
                {

                    await context.Educations.AddAsync(education);
                    await context.SaveChangesAsync();
                    return new EducationViewModel(HttpStatusCode.OK, education, null);
                }
                catch (Exception ex)
                {
                    return new EducationViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }
            
        }

        public async Task<EducationViewModel> GetAllEducations()
        {
           
                try
                {

                    var educations = await context.Educations.ToListAsync();

                    return new EducationViewModel(educations, HttpStatusCode.OK, null);
                }
                catch (Exception ex)
                {
                    return new EducationViewModel(null, HttpStatusCode.InternalServerError, ex.InnerException!.Message);
                }
            
        }

        public async Task<EducationViewModel> GetEducationById(Guid id)
        {
           
                try
                {
                    var education = await context.Educations.FirstOrDefaultAsync(c => c.Id.Equals(id));

                    if (education == null)
                    {
                        return new EducationViewModel(HttpStatusCode.NotFound, null, null);
                    }
                    return new EducationViewModel(HttpStatusCode.OK, education, null);
                }
                catch (Exception ex)
                {
                    return new EducationViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }
            
        }

        public async Task<EducationViewModel> GetEducationByName(string name)
        {
           
                try
                {
                    var education = await context.Educations.FirstOrDefaultAsync(c => c.Name.Equals(name));


                    if (education == null)
                    {
                        return new EducationViewModel(HttpStatusCode.NotFound, null, null);
                    }
                    return new EducationViewModel(HttpStatusCode.OK, education, null);
                }
                catch (Exception ex)
                {
                    return new EducationViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }

            
        }

        public async Task<EducationViewModel> Update(Education education)
        {
           
                try
                {

                    context.Educations.Update(education);
                    await context.SaveChangesAsync();
                    return new EducationViewModel(HttpStatusCode.OK, education, null);
                }
                catch (Exception ex)
                {
                    return new EducationViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }
            
        }
    }
}

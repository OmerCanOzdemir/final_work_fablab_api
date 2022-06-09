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
    public class UserProjectRepository : BaseRepository, IUserProjectRepository
    {
        private readonly Context _context;
        public UserProjectRepository(Context context) : base(context)
        {
            _context = context;

        }
        public async Task<UserProjectViewModel> GetUserProjectById(Guid id)
        {
            
                try
                {
                    var userProject = await context.Project_User.FirstOrDefaultAsync(pu => pu.Id.Equals(id));

                    if(userProject == null)
                    {
                        return new UserProjectViewModel(null, HttpStatusCode.NotFound, null);
                    }
                    
                    return new UserProjectViewModel(userProject, HttpStatusCode.OK, null);
                }
                catch (Exception ex)
                {
                    return new UserProjectViewModel(null, HttpStatusCode.InternalServerError, ex.InnerException!.Message);
               }
            
        }

        public async Task<UserProjectViewModel> GiveScore(ProjectUser projectUser)
        {
           
                try
                {

                    context.Project_User.Update(projectUser);
                    await context.SaveChangesAsync();
                    return new UserProjectViewModel(projectUser, HttpStatusCode.OK, null);
                }
                catch (Exception ex)
                {
                    return new UserProjectViewModel(projectUser, HttpStatusCode.InternalServerError, ex.InnerException!.Message);
                }
            
        }

        public async Task<UserProjectViewModel> ParticipateProject(ProjectUser userProject)
        {
           
                try
                {

                    await context.Project_User.AddAsync(userProject);
                    await context.SaveChangesAsync();
                    return new UserProjectViewModel( userProject,HttpStatusCode.OK, null);
                }
                catch (Exception ex)
                {
                    return new UserProjectViewModel(userProject,HttpStatusCode.InternalServerError, ex.InnerException!.Message);
                }
            
        }

        public async Task<UserProjectViewModel> UnParticipate(ProjectUser userProject)
        {
           
                try
                {

                    context.Project_User.Remove(userProject);
                    await context.SaveChangesAsync();
                    return new UserProjectViewModel(userProject, HttpStatusCode.OK, null);
                }
                catch (Exception ex)
                {
                    return new UserProjectViewModel(userProject, HttpStatusCode.InternalServerError, ex.InnerException!.Message);
                }
            
        }
    }
}

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
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        private readonly Context _context;
        public ProjectRepository(Context context) : base(context)
        {
            _context = context;

        }
        public async Task<ProjectViewModel> Create(Project project)
        {
           
                try
                {
                    await context.Project.AddAsync(project);
                    await context.SaveChangesAsync();
                    return new ProjectViewModel(HttpStatusCode.OK, project, null);
                }
                catch (Exception ex)
                {
                    return new ProjectViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }
            
        }

        public async Task<CommentViewModel> CreateComment(Comment comment)
        {
            try
            {
                context.Comments.Add(comment);
                await context.SaveChangesAsync();
                return new CommentViewModel(comment, HttpStatusCode.OK, null);
            }
            catch (Exception ex)
            {

                return new CommentViewModel(null, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<ProjectViewModel> Delete(Project project)
        {
            
                try
                {
                    context.Project.Update(project);
                    await context.SaveChangesAsync();
                    return new ProjectViewModel(HttpStatusCode.OK, project, null);
                }
                catch (Exception ex)
                {
                    return new ProjectViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }
            
        }

        public async Task<ProjectViewModel> GetProjectById(Guid id)
        {
            
                try
                {
                var project = await context.Project.Include(u => u.User).Include(c => c.Category).Include(p => p.Project_Users).ThenInclude(u => u.User).ThenInclude(e => e.Education).Include(p => p.Tasks).Include(p => p.Comments).ThenInclude(c => c.User).FirstOrDefaultAsync(c => c.Id.Equals(id));

                    if (project == null)
                    {
                        return new ProjectViewModel(HttpStatusCode.NotFound, null, null);
                    }
                    return new ProjectViewModel(HttpStatusCode.OK, project, null);
                }
                catch (Exception ex)
                {
                    return new ProjectViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }
            
        }

        public async Task<ProjectViewModel> GetProjects()
        {
            
                try
                {

                var projects = await context.Project.ToListAsync();
                    return new ProjectViewModel(projects, HttpStatusCode.OK, null);
                }
                catch (Exception ex)
                {
                    return new ProjectViewModel(null, HttpStatusCode.InternalServerError, ex.InnerException!.Message);
                }
            
        }

        public async Task<ProjectViewModel> Update(Project project)
        {
           
                try
                {
                    context.Project.Update(project);
                    await context.SaveChangesAsync();
                    return new ProjectViewModel(HttpStatusCode.OK, project, null);
                }
                catch (Exception ex)
                {
                    return new ProjectViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }
            
        }



    }
}

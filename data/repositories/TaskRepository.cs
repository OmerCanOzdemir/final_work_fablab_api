using data.context;
using data.models.viewModels;
using data.repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaskModel = data.models.entities.Task;
namespace data.repositories
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        private readonly Context _context;
        public TaskRepository(Context context):base(context)
        {
            _context = context;
        }
        public async Task<TaskViewModel> Assign(TaskModel task)
        {
            try
            {
                context.Tasks.Update(task);
                await context.SaveChangesAsync();
                return new TaskViewModel(task, HttpStatusCode.OK, null);
            }
            catch (Exception ex)
            {

                return new TaskViewModel(null, HttpStatusCode.InternalServerError,ex.Message);
            }
        }

        public async Task<TaskViewModel> ChangeStatus(TaskModel task)
        {
            try
            {
                context.Tasks.Update(task);
                await context.SaveChangesAsync();
                return new TaskViewModel(task, HttpStatusCode.OK, null);
            }
            catch (Exception ex)
            {

                return new TaskViewModel(null, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<TaskViewModel> CreateTask(TaskModel task)
        {
            try
            {
                await context.Tasks.AddAsync(task);
                await context.SaveChangesAsync();
                return new TaskViewModel(task, HttpStatusCode.OK, null);
            }
            catch (Exception ex)
            {

                return new TaskViewModel(null, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<TaskViewModel> DeleteTask(TaskModel task)
        {
            try
            {
                context.Tasks.Remove(task);
                await context.SaveChangesAsync();
                return new TaskViewModel(task, HttpStatusCode.OK, null);
            }
            catch (Exception ex)
            {

                return new TaskViewModel(null, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<TaskViewModel> GetTaskById(Guid id)
        {
            try
            {
                var task = await context.Tasks.Include(t => t.User).Include(t => t.Project).FirstOrDefaultAsync(x => x.Id == id);
                if (task == null)
                {
                    return new TaskViewModel(null, HttpStatusCode.NotFound, null);
                }
                    return new TaskViewModel(task, HttpStatusCode.OK, null);
            }
            catch (Exception ex)
            {

                return new TaskViewModel(null, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<TaskViewModel> UnAssign(TaskModel task)
        {
            try
            {
                context.Tasks.Update(task);
                await context.SaveChangesAsync();
              
                return new TaskViewModel(task, HttpStatusCode.OK, null);
            }
            catch (Exception ex)
            {

                return new TaskViewModel(null, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<TaskViewModel> UpdateTask(TaskModel task)
        {
            try
            {
                context.Tasks.Update(task);
                await context.SaveChangesAsync();
                return new TaskViewModel(task, HttpStatusCode.OK, null);
            }
            catch (Exception ex)
            {

                return new TaskViewModel(null, HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

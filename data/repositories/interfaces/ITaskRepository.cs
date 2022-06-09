using data.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskModel = data.models.entities.Task;
namespace data.repositories.interfaces
{
    public interface ITaskRepository
    {
        Task<TaskViewModel> CreateTask(TaskModel task);

        Task<TaskViewModel> DeleteTask(TaskModel task);

        Task<TaskViewModel> UpdateTask(TaskModel task);

        Task<TaskViewModel> GetTaskById(Guid id);

        Task<TaskViewModel> Assign(TaskModel task);
        Task<TaskViewModel> UnAssign(TaskModel task);
        Task<TaskViewModel> ChangeStatus(TaskModel task);
    }
}

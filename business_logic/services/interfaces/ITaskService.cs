using data.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskModel = data.models.entities.TaskModel;
namespace business_logic.services.interfaces
{
    public interface ITaskService
    {
        TaskViewModel CreateTask(Guid id, TaskModel task);

        TaskViewModel DeleteTask(Guid id);

        TaskViewModel UpdateTask(Guid id, TaskModel task);

        TaskViewModel GetTaskById(Guid id);

        TaskViewModel Assign(Guid Id,string userId);
        TaskViewModel UnAssign(Guid id);
        TaskViewModel ChangeStatus(Guid id,TaskModel task);
    }
}

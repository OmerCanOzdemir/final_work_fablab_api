using business_logic.services.interfaces;
using data.models.viewModels;
using data.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskModel = data.models.entities.Task;
namespace business_logic.services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public TaskViewModel Assign(Guid Id, string userId)
        {
            var taskViewModel = _taskRepository.GetTaskById(Id).Result;

            if (taskViewModel.Task == null)
            {
                return taskViewModel;
            }
            var taskDb = taskViewModel.Task;

            taskDb.UserId = userId;

            return _taskRepository.Assign(taskDb).Result;
        }

        public TaskViewModel ChangeStatus(Guid id, TaskModel task)
        {
            var taskViewModel = _taskRepository.GetTaskById(id).Result;

            if (taskViewModel.Task == null)
            {
                return taskViewModel;
            }

            var taskDb = taskViewModel.Task;

            taskDb.Status = task.Status.ToUpper();

            return _taskRepository.ChangeStatus(taskDb).Result;
        }

        public TaskViewModel CreateTask(Guid id,TaskModel task)
        {
            task.ProjectId = id;
            task.CreatedTime = DateTime.Now;
            task.Status = "OPEN";
            return _taskRepository.CreateTask(task).Result;
        }

        public TaskViewModel DeleteTask(Guid id)
        {
            var taskViewModel = _taskRepository.GetTaskById(id).Result;

            if (taskViewModel.Task == null)
            {
                return taskViewModel;
            }

            var taskDb = taskViewModel.Task;

            return _taskRepository.DeleteTask(taskDb).Result;
        }

        public TaskViewModel GetTaskById(Guid id)
        {
            return _taskRepository.GetTaskById(id).Result;
        }

        public TaskViewModel UnAssign(Guid id)
        {
            var taskViewModel = _taskRepository.GetTaskById(id).Result;

            if (taskViewModel.Task == null)
            {
                return taskViewModel;
            }

            var taskDb = taskViewModel.Task;

            taskDb.UserId = null;
            taskDb.User = null;

            return _taskRepository.UnAssign(taskDb).Result;
        }

        public TaskViewModel UpdateTask(Guid id,TaskModel task)
        {
            var taskViewModel = _taskRepository.GetTaskById(id).Result;

            if(taskViewModel.Task == null)
            {
                return taskViewModel;
            }

            var dbTask = taskViewModel.Task;

            dbTask.Title = task.Title;
            dbTask.Description = task.Description;

            return _taskRepository.UpdateTask(dbTask).Result;
        }
    }
}

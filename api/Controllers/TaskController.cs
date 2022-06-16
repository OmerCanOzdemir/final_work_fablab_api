using business_logic.services.interfaces;
using data.models.viewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TaskModel = data.models.entities.TaskModel;

namespace api.Controllers
{
    [Route("api/Tasks")]
    [EnableCors("ReactApp")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{id}")]
        public ActionResult<TaskViewModel> GetTaskById(Guid id)
        {
            return _taskService.GetTaskById(id);
        }

        [HttpPost("{id}")]
        public ActionResult<TaskViewModel> CreateTask(Guid id,TaskModel task)
        {
            return _taskService.CreateTask(id,task);
        }

        [HttpPut("assign/{id}/{userId}")]
        public ActionResult<TaskViewModel> Assign(Guid id,string userId)
        {
            return _taskService.Assign(id,userId);
        }
        [HttpPut("unAssign/{id}")]
        public ActionResult<TaskViewModel> UnAssign(Guid id)
        {
            return _taskService.UnAssign(id);
        }

        [HttpDelete("{id}")]
        public ActionResult<TaskViewModel> DeleteTask(Guid id)
        {
            return _taskService.DeleteTask(id);
        }

        [HttpPut("{id}")]
        public ActionResult<TaskViewModel> UpdateTask(Guid id,TaskModel task)
        {
            return _taskService.UpdateTask(id,task);
        }


        [HttpPut("changeStatus/{id}")]
        public ActionResult<TaskViewModel> ChangeStatus(Guid id, TaskModel task)
        {
            return _taskService.ChangeStatus(id,task);  
        }


    }
}

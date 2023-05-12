using AppTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AppTask.Controller
{
    [ApiController]
    [Route("v1")]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        [Route("tasks")]
        public List<TaskModels> GetTasks()
        { 
            return new List<TaskModels>();
        }
    }
}

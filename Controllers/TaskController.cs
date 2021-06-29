using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_API.Models;
using Web_API.Services;
//////////////Mango- http://mango.viecrew.com ///////////////////
namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        public TaskController()
        {

        }

        // GET all action
        [HttpGet]
        public ActionResult<List<TheTask>> GetAll() =>
        TaskService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<TheTask> Get(int id)
        {
            var task = TaskService.Get(id);

            if (task == null)
                return NotFound();

            return task;
        }
        // POST action
        [HttpPost]
        public IActionResult Create(TheTask task)
        {
            TaskService.Add(task);
            return CreatedAtAction(nameof(Create), new { id = task.Id }, task);
        }
        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, TheTask task)
        {
            if (id != task.Id)
                return BadRequest();

            var existingTask = TaskService.Get(id);
            if (existingTask is null)
                return NotFound();

            TaskService.Update(task);

            return NoContent();
        }
        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = TaskService.Get(id);

            if (task is null)
                return NotFound();

            TaskService.Delete(id);

            return NoContent();
        }
    }


}

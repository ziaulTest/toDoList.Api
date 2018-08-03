using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages.Html;
using Microsoft.AspNetCore.Mvc;
using toDoList.Api.Models;

namespace toDoList.Api.Controllers
{
    [Route("api/toDolist")]
    public class SubTasksController : Controller
    {
        
        [HttpGet("{id}/subTask")]
        public IActionResult getSubtasks(int id)
        {
            var listToReturn = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == id);
            if (listToReturn == null)
            {
                return NotFound();
            }

            return Ok(listToReturn.NumberOfSubTasks);
        }

        [HttpGet("{tdlid}/subTask/{id}", Name = "GetSubTasks")]
        public IActionResult getSubtasksbyId(int tdlid, int id)
        {
            var listToReturn = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == tdlid);
            if (listToReturn == null)
            {
                return NotFound();
            }

            var subTasks = listToReturn.SubTask.FirstOrDefault(p => p.Id == id);
            if (subTasks == null)
            {
                return NotFound();
            }
            return Ok(subTasks);
        }

        [HttpPost("{tdlid}/subTask")]
        public IActionResult CreatetoDoList(int tdlid, [FromBody] SubTasksCreationDto subTasks)
        {
            if (subTasks == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var listToReturn = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == tdlid);
            if (listToReturn == null)
            {
                return NotFound();
            }

            var maxId = ToDoListDataStore.Current.ToDoList.SelectMany(c => c.SubTask).Max(p => p.Id);

            var final = new SubTasksDto()
            {
                Id = ++maxId,
                task = subTasks.task,
                priority = subTasks.priority
            };

            listToReturn.SubTask.Add(final);

            return CreatedAtRoute("GetSubTasks", new {tdlid, id = final.Id}, final);

        }

    }
}


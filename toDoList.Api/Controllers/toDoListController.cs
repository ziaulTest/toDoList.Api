using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using toDoList.Api.Models;

namespace toDoList.Api.Controllers
{
    [Route("api/ToDoLists")]
    public class ToDoListController : Controller
    {

        [HttpGet]
        public IActionResult GetToDoLists()
        {
            return Ok(ToDoListDataStore.Current.ToDoList);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetToDoList(int id)
        {
            // find list 
            var listToReturn = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == id);
            if (listToReturn == null)
            {
                return NotFound();
            }

            return Ok(listToReturn);
            
        }

        [HttpPost("{id}", Name = "Post")]
        public IActionResult PostToDoList(int id, [FromBody] toDoListDto ReturnList)
        {
            if (ReturnList == null)
            {
                return BadRequest();
            }

            var final = new toDoListDto()
            {
                Id = ReturnList.Id,
                priority = ReturnList.priority,
                status = ReturnList.status,
                task = ReturnList.task
            };

            ToDoListDataStore.Current.ToDoList.Add(final);
            return CreatedAtRoute("Get", final);
        }

        [HttpPatch("{id}", Name = "Patch")]
        public IActionResult PartiallyUpdate(int id, [FromBody] toDoListDto returnList)
        {
            var toDoListItem = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == id);

            if (toDoListItem == null)
            {
                return BadRequest();
            }

            returnList.task = toDoListItem.task;
            returnList.priority = toDoListItem.priority;
        
            return Ok();

        }

        [HttpDelete("{id}" , Name = "Delete")]
        public IActionResult DeleteList(int id)
        {
            var toDoListItem = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == id);

            if (toDoListItem == null)
            {
                return NotFound();
            }

            toDoListItem.ToDolistCollection.Remove(toDoListItem);
            return Ok(toDoListItem);
        }
    }
}
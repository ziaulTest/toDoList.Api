using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using toDoList.Api.Models;

namespace toDoList.Api.Controllers
{
   [Route("api/GetToDoLists")]
    public class ToDoListController : Controller
    {
        [HttpGet]
        public IActionResult GetToDoLists()
        { 
            return Ok(ToDoListDataStore.Current.ToDoList);
        }

        [HttpGet("{id}")]
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

        [HttpDelete("{id}")]
        public IActionResult DeleteToDoList(int id)
        {
            // find list 
            var listToReturn = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == id);
            if (listToReturn == null)
            {
                return NotFound();
            }
            return Ok(listToReturn);
        }
    }
}

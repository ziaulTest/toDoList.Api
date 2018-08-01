using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using toDoList.Api.Models;

namespace toDoList.Api.Controllers
{
   
    public class ToDoListController : Controller
    {
        [HttpGet("api/GetToDoList")]
        public JsonResult GetToDoLists()
        {
            //created a new instance of the datastore and will be returning the current to do list. 
            return new JsonResult(ToDoListDataStore.Current.ToDoList);
            //return new JsonResult(new List<object>()
            //{

                    //new {id=1, task="need to add somthing here", priority = "High", status = "done" },
                    //new {id=2, task="need to add somthing or it wont work", priority = "Low", status = "Started" },
            //}
            //);
        }

        [HttpGet("api/GetToDoList/{id}")]
        public JsonResult GetToDoList()
        {


        }

    }
}

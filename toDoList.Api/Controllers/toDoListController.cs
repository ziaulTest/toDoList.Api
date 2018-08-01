using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace toDoList.Api.Controllers
{
   
    public class ToDoListController : Controller
    {
        [HttpGet("api/GetToDoList/{name}")]
        public JsonResult GetToDoList(string name)
        {
            return new JsonResult(new List<object>()
            {
                    new {id=1, name=name},
                    new {id=2, name="get Food"}
            }
            );
        }


    }
}

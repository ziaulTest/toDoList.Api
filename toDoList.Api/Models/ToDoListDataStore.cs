using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace toDoList.Api.Models
{
    public class ToDoListDataStore
    {
        public static ToDoListDataStore Current { get;} = new ToDoListDataStore();

        public List<toDoListDto> ToDoList { get; set; }

        public ToDoListDataStore()
        {
            ToDoList = new List<toDoListDto>()
            {
                new toDoListDto()
                {
                    Id = 1,
                    priority = "high",
                    task = "Wake up at 9am",
                    status = "In Progress",
                    SubTask = new List<SubTasksDto>()
                    {
                    new SubTasksDto() {
                    Id = 1,
                    task =  "go toilet earlier so i can be in bed earlier",
                    priority = "High" },
                     new SubTasksDto() {
                     Id = 2,
                     task =  "Drink less water",
                     priority = "Medium" },
            }
                },
                new toDoListDto()
                {
                    Id = 2,
                    priority = "low",
                    task = "sleep at 8pm",
                    status = "In Progress"
                },
                new toDoListDto()
                {
                    Id = 3,
                    priority = "middle",
                    task = "take the dog for a walk",
                    status = "done"
               }
            };
        }
    }
}

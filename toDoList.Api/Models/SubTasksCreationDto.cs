using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace toDoList.Api.Models
{
    public class SubTasksCreationDto
    {
        [Required(ErrorMessage = "you should provide a valid name value")]
        [MaxLength(50)]
        public string task { get; set; }
       [MaxLength(200)]
        public string priority { get; set; }
    }
}

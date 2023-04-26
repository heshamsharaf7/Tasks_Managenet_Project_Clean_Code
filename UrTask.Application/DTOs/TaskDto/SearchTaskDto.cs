using System;
using System.Collections.Generic;
using System.Text;

namespace UrTask.Application.DTOs.TaskDto
{
   public class SearchTaskDto
    {
        public IEnumerable<TaskGetDto> tasks { get; set; }
        public string SearchStatement { get; set; }

    }
}

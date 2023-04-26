using System;
using System.Collections.Generic;
using System.Linq;
using UrTask.Domain.Entities;

namespace UrTask.Application.DTOs.TaskFileDto
{
   public class TaskFileGetDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int TaskId { get; set; }
        public DateTime EnterdDate { get; set; }
        public string FileText { get; set; }

        internal TaskFileGetDto fromModel(TaskFilesMdl dto)
        {
            if (dto == null) return null;
            return new TaskFileGetDto()
            {
                Id = dto.Id,
                Path = dto.Path,
                TaskId = dto.TaskId,
                EnterdDate = dto.EnterdDate,
                FileText=dto.FileText

            };
        }
        internal List<TaskFileGetDto> fromModel(List<TaskFilesMdl> dto)
        {
            var lst = new List<TaskFileGetDto>();
            lst.AddRange(dto.Select((x) => fromModel(x)));
            return lst;
        }
    }
}

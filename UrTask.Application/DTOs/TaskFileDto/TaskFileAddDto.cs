using System;
using System.Collections.Generic;
using System.Text;
using UrTask.Domain.Entities;

namespace UrTask.Application.DTOs.TaskFileDto
{
   public class TaskFileAddDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int TaskId { get; set; }
        public DateTime EnterdDate { get; set; }
        public string FileText { get; set; }
        internal TaskFilesMdl toModel(TaskFileAddDto dto)
        {
            return new TaskFilesMdl()
            {
                
                Path=dto.Path,
                TaskId=dto.TaskId
                ,EnterdDate = DateTime.Now, 
                FileText=dto.FileText
            };
        }
        internal TaskFilesMdl toModel(int id, TaskFileAddDto dto)
        {
            return new TaskFilesMdl()
            {
                Id = id,
                Path = dto.Path,
                TaskId = dto.TaskId,
                EnterdDate = dto.EnterdDate,
                FileText=dto.FileText
            };
        }
    }
}

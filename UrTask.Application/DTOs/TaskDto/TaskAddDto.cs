using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UrTask.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace UrTask.Application.DTOs.TaskDto
{
   public class TaskAddDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يرجى ادخال المهمة")]
        public string title { get; set; }
        public DateTime EnterdDate { get; set; }
        public string Notes { get; set; }
        [Required(ErrorMessage = "يرجى تحديد تحديد التاريخ المتوقع لانتهاء المهمة")]
        public DateTime DueDate { get; set; }
        //public bool RemindeMe { get; set; }
        public int TaskStatues { get; set; }
        public int UserId { get; set; }
        public DateTime endDate { get; set; }
        public float Price { get; set; }
        public List<IFormFile> Files { get; set; }
        internal TaskMdl toModel(TaskAddDto dto)
        {
            return new TaskMdl()
            {
                title = dto.title,
                DueDate= DateTime.Now,
                Price=dto.Price,
                UserId=dto.UserId,
                TaskStatues=dto.TaskStatues,
                //RemindeMe=dto.RemindeMe,
                endDate=dto.endDate,
                Id=dto.Id,
                Notes = dto.Notes,
                EnterdDate = DateTime.Now,
                
            };
        }
        internal TaskMdl toModel(int id, TaskAddDto dto)
        {
            return new TaskMdl()
            {
                Id = id,
                title = dto.title,
                DueDate = DateTime.Now,
                Price = dto.Price,
                UserId = dto.UserId,
                TaskStatues = dto.TaskStatues,
                //RemindeMe = dto.RemindeMe,
                endDate = dto.endDate,
                Notes = dto.Notes,
                EnterdDate = dto.EnterdDate
            };
        }
    }
}

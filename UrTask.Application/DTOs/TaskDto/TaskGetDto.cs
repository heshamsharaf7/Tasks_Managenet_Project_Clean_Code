using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using UrTask.Application.DTOs.StatuesDto;
using UrTask.Application.DTOs.UserDto;
using UrTask.Application.Utils;
using UrTask.Domain.Entities;

namespace UrTask.Application.DTOs.TaskDto
{
   public class TaskGetDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Please enter the title of your book")]
        public string title { get; set; }
        public DateTime EnterdDate { get; set; }
        public string Notes { get; set; }
        public DateTime DueDate { get; set; }
        //public bool RemindeMe { get; set; }
        public int TaskStatuesId { get; set; }
        public string TaskStatuesName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime endDate { get; set; }
        public float Price { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<string> FilesTexts { get; set; }



        internal TaskGetDto fromModel(TaskMdl dto, IList<StatuesValueDto> lstStatuesValues, IList<UserValueDto> lstUserValues)
        {
            if (dto == null) return null;
            return new TaskGetDto()
            {
                Id = dto.Id,
                title = dto.title,
                DueDate = dto.DueDate,
                Price = dto.Price,
                UserId = dto.UserId,
                TaskStatuesId = dto.TaskStatues,
                //RemindeMe = dto.RemindeMe,
                endDate = dto.endDate,
                Notes = dto.Notes,
                EnterdDate = dto.EnterdDate,
                TaskStatuesName = lstStatuesValues.GetValueStr(a => a.id == dto.TaskStatues
                    , PropertyHelper.GetPropertyName((StatuesValueDto v) => v.name)),
                UserName = lstUserValues.GetValueStr(a => a.id == dto.UserId
                    , PropertyHelper.GetPropertyName((UserValueDto v) => v.name)),

            };
        }
        internal List<TaskGetDto> fromModel(List<TaskMdl> dto)
        {
            var lstStatuesValues = new StatuesValueDto().GetAll();
            var lstUserValues = new UserValueDto().GetAll();
            var lst = new List<TaskGetDto>();
            lst.AddRange(dto.Select((x) => fromModel(x,lstStatuesValues, lstUserValues)));
            return lst;
        }
    }
}

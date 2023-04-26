using System;
using System.Collections.Generic;
using UrTask.Application.DTOs.AnswersDto;
using UrTask.Application.DTOs.StatuesDto;
using UrTask.Application.DTOs.UserDto;
using UrTask.Application.Utils;
using UrTask.Domain.Entities;

namespace UrTask.Application.DTOs.TaskDto
{
   public class TaskDetailsDto
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
        public List<string> FilesPath { get; set; }
        public IList<AnswerGetDto> Answers { get; set; }
        internal TaskDetailsDto fromModel(TaskMdl dto, IList<StatuesValueDto> lstStatuesValues, IList<UserValueDto> lstUserValues)
        {
            if (dto == null) return null;
            return new TaskDetailsDto()
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
        internal TaskDetailsDto fromModel(TaskMdl dto)
        {
            var lstStatuesValues = new StatuesValueDto().GetAll();
            var lstUserValues = new UserValueDto().GetAll();
            var task = new TaskDetailsDto().fromModel(dto, lstStatuesValues, lstUserValues);
            return task;
        }
    }
}

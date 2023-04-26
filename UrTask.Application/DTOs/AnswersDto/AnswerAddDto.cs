using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UrTask.Domain.Entities;

namespace UrTask.Application.DTOs.AnswersDto
{
    public class AnswerAddDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يرجى ادخال نص الاجابة")]
        public string Notes { get; set; }
        public int TaskId { get; set; }
        public List<IFormFile> Files { get; set; }
        internal DeliveryMdl toModel(AnswerAddDto dto)
        {
            return new DeliveryMdl()
            {
               
                Id = dto.Id,
                Notes = dto.Notes,
                EnterdDate = DateTime.Now,
                TaskId=dto.TaskId

            };
        }
        internal DeliveryMdl toModel(int id, AnswerAddDto dto)
        {
            return new DeliveryMdl()
            {
                Id = id,
                Notes = dto.Notes,
                EnterdDate = DateTime.Now,
                TaskId = dto.TaskId
            };
        }
    }
}

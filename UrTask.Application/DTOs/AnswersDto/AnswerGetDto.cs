using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using UrTask.Domain.Entities;

namespace UrTask.Application.DTOs.AnswersDto
{
  public  class AnswerGetDto
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public DateTime EnterdDate { get; set; }
        public int TaskId { get; set; }
        public List<string> FilesPath { get; set; }


        internal AnswerGetDto fromModel(DeliveryMdl dto)
        {
            if (dto == null) return null;
            return new AnswerGetDto()
            {
                Id = dto.Id,
                Notes = dto.Notes,
                EnterdDate=dto.EnterdDate,
            };
        }
        internal List<AnswerGetDto> fromModel(List<DeliveryMdl> dto)
        {
            var lst = new List<AnswerGetDto>();
            lst.AddRange(dto.Select((x) => fromModel(x)));
            return lst;
        }
    }
}

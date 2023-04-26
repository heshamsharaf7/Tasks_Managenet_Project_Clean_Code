using System;
using System.Collections.Generic;
using System.Linq;
using UrTask.Domain.Entities;

namespace UrTask.Application.DTOs.MajorDto
{
   public class MajorGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime EnterdDate { get; set; }
        internal MajorGetDto fromModel(MajorMdl dto)
        {
            if (dto == null) return null;
            return new MajorGetDto()
            {
                Id = dto.Id,
                Name = dto.Name,
                Notes = dto.Notes,
                EnterdDate = dto.EnterdDate

            };
        }
        internal List<MajorGetDto> fromModel(List<MajorMdl> dto)
        {
            var lst = new List<MajorGetDto>();
            lst.AddRange(dto.Select((x) => fromModel(x)));
            return lst;
        }
    }
}

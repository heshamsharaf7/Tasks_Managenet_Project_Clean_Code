using System;
using System.ComponentModel.DataAnnotations;
using UrTask.Domain.Entities;

namespace UrTask.Application.DTOs.MajorDto
{
   public class MajorUpdateDto
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your book")]
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime EnterdDate { get; set; }


        internal MajorMdl toModel(MajorUpdateDto dto)
        {
            return new MajorMdl()
            {
                Name = dto.Name,
                Notes = dto.Notes,
                EnterdDate = dto.EnterdDate
            };
        }
        internal MajorMdl toModel(int id, MajorUpdateDto dto)
        {
            return new MajorMdl()
            {
                Id = id,
                Name = dto.Name,
                Notes = dto.Notes,
                EnterdDate = dto.EnterdDate
            };

        }
        internal MajorUpdateDto fromModel(MajorMdl dto)
        {
            if (dto == null) return null;
            return new MajorUpdateDto()
            {
                Id = dto.Id,
                Name = dto.Name,
                Notes = dto.Notes,
                EnterdDate = dto.EnterdDate

            };
        }
        

    }
}

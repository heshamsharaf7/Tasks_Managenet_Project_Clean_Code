using System;
using System.ComponentModel.DataAnnotations;
using UrTask.Domain.Entities;

namespace UrTask.Application.DTOs.MajorDto
{
  public  class MajorAddDto
    {
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your book")]
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime EnterdDate { get; set; }
       

        internal MajorMdl toModel(MajorAddDto dto)
        {
            return new MajorMdl()
            {
                Name = dto.Name,
                Notes=dto.Notes,
                EnterdDate=dto.EnterdDate
            };
        }
        internal MajorMdl toModel(int id, MajorAddDto dto)
        {
            return new MajorMdl()
            {
                Id = id,
                Name = dto.Name,
                Notes = dto.Notes,
                EnterdDate = dto.EnterdDate
            };
        }

    }
}

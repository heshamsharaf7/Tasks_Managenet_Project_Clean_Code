using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrTask.Domain.Entities;

namespace UrTask.Application.DTOs.ContactDto
{
   public class ContactGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EnnterdDate { get; set; }
        public string Message { get; set; }
        public int PhoneNumber { get; set; }
        internal ContactGetDto fromModel(ContactMdl dto)
        {
            if (dto == null) return null;
            return new ContactGetDto()
            {
                Id = dto.Id,
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                EnnterdDate = dto.EnnterdDate,
                Message = dto.Message

            };
        }
        internal List<ContactGetDto> fromModel(List<ContactMdl> dto)
        {
            var lst = new List<ContactGetDto>();
            lst.AddRange(dto.Select((x) => fromModel(x)));
            return lst;
        }
    }
}

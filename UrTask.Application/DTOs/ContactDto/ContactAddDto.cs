using System;
using System.Collections.Generic;
using System.Text;
using UrTask.Domain.Entities;

namespace UrTask.Application.DTOs.ContactDto
{
   public class ContactAddDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EnnterdDate { get; set; }
        public string Message { get; set; }
        public int PhoneNumber { get; set; }


        internal ContactMdl toModel(ContactAddDto dto)
        {
            return new ContactMdl()
            {
                Id = dto.Id,
                Name = dto.Name,   
                PhoneNumber = dto.PhoneNumber,
                EnnterdDate=dto.EnnterdDate,
                Message=dto.Message


            };
        }
        internal ContactMdl toModel(int id, ContactAddDto dto)
        {
            return new ContactMdl()
            {
                Id = dto.Id,
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                EnnterdDate = dto.EnnterdDate,
                Message = dto.Message


            };
        }
    }
}

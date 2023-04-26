using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UrTask.Domain.Entities;

namespace UrTask.Application.DTOs.UserDto
{
  public  class UserAddDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يرجى ادخال الاسم")]
        public string Name { get; set; }
        [Required(ErrorMessage = "يرجى ادخال الايميل")]
        public string Email { get; set; }
        public DateTime RegisterdDate { get; set; }
        public bool Gender { get; set; }
        public string Photo { get; set; }
        public int TypeId { get; set; }
        public DateTime AccadimicYear { get; set; }
        public int MajorId { get; set; }

        [Required(ErrorMessage = "يرجى كتابة كلمة المرور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "يرجى تأكيد كلمة المرور")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "يرجى ادخال رقم الهاتف حتى نتمككن من التواصل معكم")]
        public int PhoneNumber { get; set; }
        public int AccountNo { get; set; }
        public bool Closed { get; set; }
        public IFormFile PhotoFiles { get; set; }


        internal UserMdl toModel(UserAddDto dto)
        {
            return new UserMdl()
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                MajorId = dto.MajorId,
                Password = dto.Password,
                RegisterdDate = dto.RegisterdDate,
                Photo = dto.Photo,
                Gender = dto.Gender,
                TypeId = dto.TypeId,
                Closed = dto.Closed,
                PhoneNumber=dto.PhoneNumber,

                AccadimicYear = dto.AccadimicYear

            };
        }
        internal UserMdl toModel(int id, UserAddDto dto)
        {
            return new UserMdl()
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                MajorId = dto.MajorId,
                Password = dto.Password,
                RegisterdDate = dto.RegisterdDate,
                Photo = dto.Photo,
                Gender = dto.Gender,
                TypeId = dto.TypeId,
                Closed = dto.Closed,

                AccadimicYear = dto.AccadimicYear
            };
        }
    }
}

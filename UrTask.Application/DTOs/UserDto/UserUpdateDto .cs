using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using UrTask.Application.DTOs.StatuesDto;
using UrTask.Application.Utils;
using UrTask.Domain.Entities;

namespace UrTask.Application.DTOs.UserDto
{
   public class UserUpdateDto
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
        public string MajorName { get; set; }
        [Required(ErrorMessage = "يرجى كتابة كلمة المرور")]
        public string Password { get; set; }
        public int AccountNo { get; set; }
        public bool Closed { get; set; }
        public bool RemberMe { get; set; }
        [Required(ErrorMessage = "يرجى ادخال رقم الهاتف حتى نتمككن من التواصل معكم")]
        public int PhoneNumber { get; set; }


        internal UserMdl toModel(UserUpdateDto dto)
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
                PhoneNumber=dto.PhoneNumber
               
            };
        }
        internal UserMdl toModel(int id, UserUpdateDto dto)
        {
            return new UserMdl()
            {
                Id = id,
                Name = dto.Name,
                Email = dto.Email,
                MajorId = dto.MajorId,
                Password = dto.Password,
                RegisterdDate = dto.RegisterdDate,
                Photo = dto.Photo,
                Gender = dto.Gender,
                TypeId = dto.TypeId,
                Closed = dto.Closed,
                PhoneNumber = dto.PhoneNumber

            };

        }
        internal UserUpdateDto fromModel(UserMdl dto)
        {
            if (dto == null) return null;
            return new UserUpdateDto()
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
                PhoneNumber = dto.PhoneNumber


            };
        }
    }
}

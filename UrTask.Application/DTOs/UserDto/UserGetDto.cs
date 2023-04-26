using System;
using System.Collections.Generic;
using System.Linq;
using UrTask.Application.DTOs.StatuesDto;
using UrTask.Application.Utils;
using UrTask.Domain.Entities;

namespace UrTask.Application.DTOs.UserDto
{
  public  class UserGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegisterdDate { get; set; }
        public bool Gender { get; set; }
        public string Photo { get; set; }
        public int TypeId { get; set; }
        public DateTime AccadimicYear { get; set; }
        public int MajorId { get; set; }
        public string MajorName { get; set; }
        public string Password { get; set; }
        public int AccountNo{ get; set; }
        public bool Closed { get; set; }
        public bool RemberMe { get; set; }
        public int PhoneNumber { get; set; }

        internal UserGetDto fromModel(UserMdl dto, IList<MajorValueDto> lstMajorValues)
        {
            if (dto == null) return null;
            return new UserGetDto()
            {
                Id = dto.Id,
                Name = dto.Name,
                Email=dto.Email,
                MajorId=dto.MajorId,
                Password=dto.Password,
                RegisterdDate=dto.RegisterdDate,
                Photo=dto.Photo,
                Gender=dto.Gender,
                AccountNo=dto.AccountNoId,
                 TypeId=dto.TypeId,
                 Closed=dto.Closed,
                 MajorName= lstMajorValues.GetValueStr(a => a.id == dto.MajorId
                    , PropertyHelper.GetPropertyName((MajorValueDto v) => v.name)),
                AccadimicYear =dto.AccadimicYear,
                PhoneNumber=dto.PhoneNumber

            };
        }
        internal List<UserGetDto> fromModel(List<UserMdl> dto)
        {
            var lst = new List<UserGetDto>();
            var lstMajorValues = new MajorValueDto().GetAll();

            lst.AddRange(dto.Select((x) => fromModel(x, lstMajorValues)));
            return lst;
        }

        internal UserGetDto fromModelONE(UserMdl dto)
        {
            var lstMajorValues = new MajorValueDto().GetAll();

            return fromModel(dto, lstMajorValues);
        }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrTask.Application.DTOs.UserDto;

namespace Web.Shared
{
    public class UserInfo : IdentityUser
    {
        public  UserGetDto user { set; get; }

    }
}

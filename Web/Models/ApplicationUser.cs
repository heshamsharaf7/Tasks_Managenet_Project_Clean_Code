﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }
        public string FristName { get; set; }
    }
}

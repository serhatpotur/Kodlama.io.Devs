﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Dtos
{
    public class LoginedUserDto
    {
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

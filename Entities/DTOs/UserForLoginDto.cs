﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForLoginDto:IDtos
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

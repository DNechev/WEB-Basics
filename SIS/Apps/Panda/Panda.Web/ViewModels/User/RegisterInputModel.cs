﻿using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Web.ViewModels.User
{
    public class RegisterInputModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Username should be between 5 and 20 symbols!")]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 20, "Username should be between 5 and 20 symbols!")]
        public string Email { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }
    }
}

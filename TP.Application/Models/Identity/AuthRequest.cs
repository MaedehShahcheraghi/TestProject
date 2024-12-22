using System;
using System.Collections.Generic;
using System.Text;
using TP.Application.Models.Captcha;

namespace TP.Application
{
    public class AuthRequest:BaseCaptcha
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}

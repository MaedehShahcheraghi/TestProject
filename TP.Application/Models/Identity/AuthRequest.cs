using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Application
{
    public class AuthRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string CaptchaCode { get; set; }
    }
}

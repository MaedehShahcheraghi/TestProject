using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Application.Models.Captcha
{
    public class CaptchaResponse
    {
        public string CaptchaId { get; set; }
        public string CaptchaCode { get; set; }
        public DateTime ExpiryTime { get; set; }
        public CaptchaStatus CaptchaStatus { get; set; }
    }
}

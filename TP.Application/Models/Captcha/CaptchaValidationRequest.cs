using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Application.Models.Captcha
{
    public class CaptchaValidationRequest:BaseCaptcha
    {
        public string CaptchaId { get; set; }
    }
    public enum CaptchaStatus
    {
        //indicates that the request was well-formed but was unable to be followed due to semantic errors
        UnprocessableEntity = 422,
        //indicates that the requested resource is no longer available.
        Gone = 410,
        //indicates that the request succeeded 
        Ok = 200,
        // indicates that the requested resource does not exist on the server
        NotFound = 404,
        //indicates that the request could not be understood by the server
        BadRequest =400
    }
}

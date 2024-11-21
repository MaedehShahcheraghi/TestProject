using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Application
{
    public class BadRequestException:ApplicationException
    {
        public BadRequestException(string Message):base(Message) 
        {
            
        }
    }
}

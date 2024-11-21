using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Application
{
    public class NotFoundException:ApplicationException
    {
        public NotFoundException(string name,object key):base($"{name} {key} Not Found")
        {
            
        }
    }
}

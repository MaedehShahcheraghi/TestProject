using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Application.Models.Redis
{
    public class RedisSertting
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
        public int Database { get; set; }
    }
}

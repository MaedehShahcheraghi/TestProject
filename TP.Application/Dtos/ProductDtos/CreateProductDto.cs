using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Dtos.CommonDtos;
using TP.Application.Models.Captcha;

namespace TP.Application.Dtos.ProductDtos
{
    public class CreateProductDto: BaseCaptcha, IProductDto
    {
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }

    }
}

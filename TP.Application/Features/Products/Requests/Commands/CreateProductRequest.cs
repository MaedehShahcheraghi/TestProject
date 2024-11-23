using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Dtos.ProductDtos;
using TP.Application.Responses;

namespace TP.Application.Features.Products.Requests.Commands
{
    public class CreateProductRequest:IRequest<BaseCommandResponse>
    {
        public string CreateBy { get; set; }
        public CreateProductDto CreateProductDto { get; set; }
    }
}

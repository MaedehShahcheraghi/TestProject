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
    public class EditProductRequest:IRequest<BaseCommandResponse>
    {
        public string CurrentUserId { get; set; }
        public EditProductDto EditProductDto { get; set; }
    }
}

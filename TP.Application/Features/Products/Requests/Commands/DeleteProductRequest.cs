using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Responses;

namespace TP.Application.Features.Products.Requests.Commands
{
    public class DeleteProductRequest:IRequest<BaseCommandResponse>
    {
        public int ProductId { get; set; }
        public string CurrentUserId { get; set; }
    }
}

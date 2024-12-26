using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP.Application;
using TP.Application.ApplicationExtention.UserExtention;
using TP.Application.Constants;
using TP.Application.Dtos.ProductDtos;
using TP.Application.Features.Products.Handlers.Queries;
using TP.Application.Features.Products.Requests.Commands;
using TP.Application.Features.Products.Requests.Queries;
using TP.Application.Responses;

namespace TestProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet("/GetAllProductWithFilter")]
        public async Task<ActionResult<RequestResponse<IReadOnlyList<ProductDto>>>> Get(string? ownerId)
        {
            var response = await _mediator.Send(new GetAllProductWithFilterRequest() { CreateBy=ownerId});

            if (response.StatusCode == "404")
            {
                return NotFound();
            }

            return Ok(response);

        }


    

        [HttpGet("/GetAllProduct")]
        [Authorize(Roles = "User,Adminstrator")]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> Get()
        {
            var response = await _mediator.Send(new GetAllProductRequest());
            return Ok(response);
        }


        [ServiceFilter(typeof(ValidateCaptchaAttribute))]
        [HttpPost("/AddProduct")]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>> Post( [FromBody] CreateProductDto createProductDto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var createdBy = User.GetUserId();
                if (createdBy != null)
                {
                  
                    var command = new CreateProductRequest() { CreateProductDto = createProductDto,CreateBy=createdBy };
                    var response = await _mediator.Send(command);
                    return Ok(response);
                }
            }
            return BadRequest();
        }

     
        [HttpPut("/EditProduct")]  
        [Authorize(Policy =CustomPloicy.AccessToEditProducts)]
     
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] EditProductDto editProductDto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentuserid = User.GetUserId();
                if (currentuserid != null)
                {

                    var command = new EditProductRequest() { EditProductDto = editProductDto, CurrentUserId = currentuserid };
                    var response = await _mediator.Send(command);
                    return Ok(response);
                }
            }
            return BadRequest();
        }



        [HttpDelete("/DeleteProduct/{productId}")]
        [Authorize(Policy = CustomPloicy.AccessToDeleteProducts)]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int productId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentuserid = User.GetUserId();
                if (currentuserid != null)
                {

                    var command = new DeleteProductRequest() { ProductId = productId, CurrentUserId = currentuserid };
                    var response = await _mediator.Send(command);
                    return Ok(response);
                }
            }
            return BadRequest();
        }
    }
}

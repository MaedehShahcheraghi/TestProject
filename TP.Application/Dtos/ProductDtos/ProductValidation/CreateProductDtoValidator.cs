using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Contracts.Persistence;


namespace TP.Application.Dtos.ProductDtos.ProductValidation
{
    public class CreateProductDtoValidator:AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator(IProductRepository productRepository)
        {
           
            Include(new ProductDtoValidation(productRepository));
        }
    }
}

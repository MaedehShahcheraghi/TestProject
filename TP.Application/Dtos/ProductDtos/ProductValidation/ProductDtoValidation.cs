using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Contracts.Persistence;

namespace TP.Application.Dtos.ProductDtos.ProductValidation
{
    public class ProductDtoValidation : AbstractValidator<IProductDto>
    {
        private readonly IProductRepository _productRepository;

        public ProductDtoValidation(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100");

            RuleFor(p => p.ManufactureEmail).NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull()
             .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100");


            RuleFor(p => p.ManufacturePhone).NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(15).WithMessage("{PropertyName} must not exceed 15");


            RuleFor(p => new { p.ManufactureEmail, p.ProduceDate })
              .MustAsync(async (data, token) =>
                 {
                     var productexist = await _productRepository.ExistProductByEmailandPrdouctDate(data.ManufactureEmail, data.ProduceDate);
                     return !productexist;
                 })
              .WithMessage("A product with the manufacturer email and production date  already exists."); ;

        }
    }
}

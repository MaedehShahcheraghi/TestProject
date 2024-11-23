using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.UnitTest.ProductMoq;
using TP.Application.Contracts.Persistence;
using TP.Application.Dtos.ProductDtos;
using TP.Application.Features.Products.Handlers.Commands;
using TP.Application.Features.Products.Requests.Commands;
using TP.Application.Profiles;
using TP.Application.Responses;
using TP.Domain;

namespace TestProject.Application.UnitTest.Products.Commands
{
    public class CreateProductRequestHandlerTest
    {
        IMapper _mapper;
        Mock<IProductRepository> _ProductRepository;
        Mock<IUserRepository> _UserRepository;
        public CreateProductRequestHandlerTest()
        {
            _ProductRepository = MoqProductRepository.GetProductReposittory();
            _UserRepository = MoqUserRepository.GetUserReposittory();
            var mapperconfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = mapperconfig.CreateMapper();
        }

        [Fact]
        public async Task CreateProductRequestHandlerTestMethod()
        {
            var handel = new CreateProductRequestHandler(_ProductRepository.Object, _UserRepository.Object, _mapper);
            var result = await handel.Handle(new CreateProductRequest()
            {
                CreateProductDto = new CreateProductDto()
                {

                    Name = "Product 11",
                    ManufacturePhone = "09925772867",
                    ManufactureEmail = "maedeh.shahcheraghi2011@gmail.com",
                    ProduceDate = DateTime.Now,
                    IsAvailable = true,
                },
                CreateBy = "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41"
            }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse>();
            var Products = await _ProductRepository.Object.GetAllAsync();
            Products.Count.ShouldBe(3);

        }
    }
}

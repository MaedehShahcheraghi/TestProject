using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Contracts.Persistence;
using TP.Domain;

namespace TestProject.Application.UnitTest.ProductMoq
{
    public class MoqProductRepository
    {
        public static Mock<IProductRepository> GetProductReposittory()
        {
            var Products = new List<Product>()
            {        new Product()
                 {
                     Id = 9,
                     Name = "Product 10",
                     ManufacturePhone = "09925772867",
                     ManufactureEmail = "maedeh.shahcheraghi2006@gmail.com",
                     ProduceDate = DateTime.Now,
                     CreatedBy = "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                     IsAvailable = true,
                 },
                      new Product()
                 {
                     Id = 10,
                     Name = "Product 10",
                     ManufacturePhone = "09925772867",
                     ManufactureEmail = "maedeh.shahcheraghi2007@gmail.com",
                     ProduceDate = DateTime.Now,
                     CreatedBy = "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                     IsAvailable = true,
                 }
            };
            var mockrepository = new Mock<IProductRepository>();
            //get all data
            mockrepository.Setup(r => r.GetAllAsync(It.IsAny<Expression<Func<Product, bool>>>()))
             .ReturnsAsync((Expression<Func<Product, bool>> filter) =>
                {   

                   if (filter == null)
                     {
                        return Products.ToList();
                     }


              return Products.AsQueryable().Where(filter).ToList();
             });


            //add data
            mockrepository.Setup(r => r.AddAsync(It.IsAny<Product>())).ReturnsAsync(
                (Product product) =>
                {
                    Products.Add(product);
                    return product;
                });


            //edit data

            //Update data
            //mockrepository.Setup(r => r.UpdateAsync(It.IsAny<Product>())).Returns(Task.Run(() =>
            //{
            //    var product = It.IsAny<Product>();
            //    var existingProduct = Products.FirstOrDefault(p => p.Id == product.Id);
            //    if (existingProduct != null)
            //    {
            //        existingProduct.Name = product.Name;
            //        existingProduct.ManufactureEmail = product.ManufactureEmail;
            //        existingProduct.ProduceDate = product.ProduceDate;
            //    }
            //}));

            //delete data

            //mockrepository.Setup(r => r.DeleteAsync(It.IsAny<Product>())).Returns(Task.Run(() =>
            //{

            //    var productToRemove = It.IsAny<Product>();

            //    var existingProduct = Products.FirstOrDefault(p => p.Id == productToRemove.Id);

            //    if (existingProduct != null)
            //    {
            //        Products.Remove(existingProduct);
            //    }
            //}));



            return mockrepository;


        }
    }
}

using Data;
using Data.Entities;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ProductService
    {
        private readonly AppDbContext context;

        public ProductService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Product> GetAll()
        {
            return new List<Product>(this.context.Products);
        }

        public void Create(ProductDto product)
        {
            this.context.Products.Add(this.OfProductDto(product));
            this.context.SaveChanges();
        }

        public Product GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id must not be null");
            }

            var product = context.Products
                .FirstOrDefault(m => m.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException("Id must not be null");
                //throw new EntityNotFoundException("");
            }

            return product;
        }

        public Product Edit(int? id, ProductDto newProduct)
        {
            Product returnProduct = null;

            if (id == null)
            {
                throw new ArgumentNullException("Id must not be null");
            }

            try
            {
                returnProduct = context.Update(this.OfProductDto(newProduct)).Entity;
                context.SaveChanges();
            }
            catch (Exception)
            {
                var product = this.context.Products
                    .FirstOrDefault(x => x.Id == id);

                if (product == null)
                {
                    throw new ArgumentNullException("Id must not be null");
                    //throw new EntityNotFoundException("");
                }
                else
                {
                    throw new Exception("Some Reason");
                }
            }

            return returnProduct;
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id must not be null");
            }

            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
        }

        private Product OfProductDto(ProductDto productDto)
        {
            return new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Quantity = productDto.Quantity,
                Price = productDto.Price
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apirestful.Data;
using apirestful.Models;
using apirestful.Repositories;
using Microsoft.EntityFrameworkCore;

namespace apirestful.Services
{
    public class ProductsServices : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductsServices(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Product Product)
        {
            await context.Products.AddAsync(Product);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var productFound = await GetId(id);
            if (productFound == null)
            {
                return false;
            }
            else
            {
                context.Products.Remove(productFound);
                context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetId(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task<Product> Update(int id, Product product)
        {
            var productFound = await GetId(id);
            if (productFound == null)
            {
                return productFound;
            }
            else
            {
                productFound.Name = product.Name;
                productFound.Description = product.Description;
                productFound.Price = product.Price;
                productFound.Stock = product.Stock;
                productFound.IdCategory = product.IdCategory;
                await context.SaveChangesAsync();
                return productFound;
            }
        }
    }
}
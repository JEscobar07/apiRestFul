using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apirestful.Models;

namespace apirestful.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAll();
        public Task<Product> GetId(int id);
        public Task Add(Product Product);
        public Task<Product> Update(int id, Product product);
        public Task<bool> Delete(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apirestful.Models;

namespace apirestful.Repositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAll();
        public Task<Category> GetId(int id);
        public Task Add(Category category);
        public Task<Category> Update(int id, Category category);
        public Task<bool> Delete(int id);

    }
}
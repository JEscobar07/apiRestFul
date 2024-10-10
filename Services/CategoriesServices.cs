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
    public class CategoriesServices : ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoriesServices(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var categoryFound = await GetId(id);
            if (categoryFound == null)
            {
                return false;
            }
            else
            {
                context.Categories.Remove(categoryFound);
                context.SaveChangesAsync();
                return true;
            }

        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetId(int id)
        {
            return await context.Categories.FindAsync(id);
        }

        public async Task<Category> Update(int id, Category category)
        {
            var categoryFound = await GetId(id);
            if (categoryFound == null)
            {
                return categoryFound;
            }
            else
            {
                categoryFound.Name = category.Name;
                categoryFound.Description = category.Description;
                await context.SaveChangesAsync();
                return categoryFound;
            }
        }
    }
}
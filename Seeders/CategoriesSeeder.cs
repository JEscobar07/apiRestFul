using apirestful.Models;
using Microsoft.EntityFrameworkCore;

namespace apirestful.Seeders
{
    public class CategoriesSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electrónica", Description = "Descripcion 1 poderosa" },
            new Category { Id = 2, Name = "Hogar", Description = "Descripcion 2 intrigrante" },
            new Category { Id = 3, Name = "Ropa", Description = "Descripcion 3 practica" }
            );
        }
    }
}
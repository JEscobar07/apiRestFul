using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apirestful.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace apirestful.Seeders
{
    public class ProductsSeeder
    {
        public static void Seed(ModelBuilder modelBuilder, int amout)
        {
            var products = GenerateProducts(amout);
            modelBuilder.Entity<Product>().HasData(products);
        }

        public static IEnumerable<Product> GenerateProducts(int count)
        {
            var faker = new Faker<Product>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName()) 
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Price, f => double.Parse(f.Commerce.Price(1, 1000)))
                .RuleFor(p => p.Stock, f => f.Random.Int(0, 100)) 
                .RuleFor(p => p.IdCategory, f => f.PickRandom(1, 2, 3));

            return faker.Generate(count);
        }

    }
}
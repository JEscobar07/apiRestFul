using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apirestful.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace apirestful.Data
{
    public class AppDbContext : DbContext
    {
        DbSet<Category> Categories {get; set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
  
        }
    }
}
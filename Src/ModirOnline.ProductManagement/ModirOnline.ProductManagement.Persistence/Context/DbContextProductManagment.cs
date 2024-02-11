
using Microsoft.EntityFrameworkCore;
using ModirOnline.ProductManagement.Application.Interface;
using ModirOnlline.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModirOnline.ProductManagement.Persistence.Context
{
    public class DbContextProductManagment : DbContext, IDbContextProductManagement
    {
        public DbContextProductManagment(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }
        public DbSet<MaterialUsed> MaterialUseds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelCreating.ConfigForeignKeys(modelBuilder);
            ModelCreating.ConfigGeneratedValue(modelBuilder);
            ModelCreating.DataSeeding(modelBuilder);
        }
    }
}


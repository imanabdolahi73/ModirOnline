
using Microsoft.EntityFrameworkCore;
using ModirOnline.Common.BaseInrerfaces;
using ModirOnlline.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModirOnline.ProductManagement.Application.Interface
{
    public interface IDbContextProductManagement : IBaseDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }
        public DbSet<MaterialUsed> MaterialUseds { get; set; }
    }
}

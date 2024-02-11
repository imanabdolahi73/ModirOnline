using Microsoft.EntityFrameworkCore;

namespace ModirOnline.ProductManagement.Persistence.Context
{
    public static class ModelCreating
    {
        public static void ConfigForeignKeys(ModelBuilder modelBuilder)
        {
            //جلوگیری از خطای کلید خارجی در بروزرسانی دیتابیس
            //modelBuilder.Entity<MaterialUsed>()
            //    .HasOne(mu => mu.Product)
            //    .WithMany(p => p.MaterialUseds)
            //    .HasForeignKey(mu => mu.ProductId)
            //    .OnDelete(DeleteBehavior.NoAction);
            
        }

        public static void ConfigGeneratedValue(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<SysLog>().Property(p => p.Insert_DateTime).HasDefaultValueSql("getdate()");
        }

        public static void DataSeeding(ModelBuilder modelBuilder)
        {
            
            //modelBuilder.Entity<Person>()
            //    .HasData(
            //    new Person { Id = 1, FullName = "ایمان عبدالهی", Email = "abdollahi.iman73@gmail.com", PersonType = PersonType.Employee, ProfilePhotoAddress = "/admintemplate/assets/media/image/user/abdollahi.jpg" }
            //    );

        }
    }
}

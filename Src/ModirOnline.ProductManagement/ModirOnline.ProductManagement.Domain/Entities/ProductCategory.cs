using ModirOnline.Common.BaseClasses;

namespace ModirOnlline.ProductManagement.Domain.Entities
{
    public class ProductCategory : BaseEntity<long>
    {
        public string Title { get; set; } = string.Empty;
        public virtual ICollection<Product> Products { get; } = new List<Product>();
    }
}

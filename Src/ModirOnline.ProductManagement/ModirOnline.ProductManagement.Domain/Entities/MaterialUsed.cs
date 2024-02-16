using ModirOnline.Common.BaseClasses;

namespace ModirOnlline.ProductManagement.Domain.Entities
{
    public class MaterialUsed : BaseEntity<long>
    {
        public long MaterialId { get; set; }
        public long ProductId { get; set; }
        public int Amount { get; set; }
        public string Title { get; set; } = string.Empty;
        public virtual Material Material { get; set; } = new Material();
        public virtual Product Product { get; set; } = new Product();
    }
}

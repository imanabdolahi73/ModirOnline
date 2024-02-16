using ModirOnline.Common.BaseClasses;

namespace ModirOnlline.ProductManagement.Domain.Entities
{
    public class Product : BaseEntity<long>
    {
        public string Title { get; set; } = string.Empty;
        public long Price { get; set; }
        public string? PhotoAddress { get; set; }
        public bool IsHidden { get; set; }
        public long ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; } = new ProductCategory();
        public virtual ICollection<MaterialUsed> MaterialUseds { get; } = new List<MaterialUsed>();
    }
}

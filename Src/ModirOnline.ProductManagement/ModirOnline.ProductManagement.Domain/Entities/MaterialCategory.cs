using ModirOnline.Common.BaseClasses;

namespace ModirOnlline.ProductManagement.Domain.Entities
{
    public class MaterialCategory : BaseEntity<long>
    {
        public string Title { get; set; } = string.Empty;
        public virtual ICollection<Material> Materials { get; } = new List<Material>();
    }
}

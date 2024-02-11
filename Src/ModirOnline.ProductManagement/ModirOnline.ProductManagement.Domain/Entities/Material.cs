using ModirOnline.Common.Dto;
using ModirOnline.Common.Enums;

namespace ModirOnlline.ProductManagement.Domain.Entities
{
    public class Material : BaseEntity<long>
    {
        public string Title { get; set; } = string.Empty;
        public MaterialUnitType MaterialUnitType { get; set; }
        public bool IsHidden { get; set; }
        public long MaterialCategoryId { get; set; }
        public virtual MaterialCategory MaterialCategory { get; set; } = new MaterialCategory();
        public virtual ICollection<MaterialUsed> MaterialUseds { get; } = new List<MaterialUsed>();
    }
}

using System.ComponentModel.DataAnnotations;
using ModirOnline.Common.BaseClasses;

namespace ModirOnline.Common.Dto.ProductManagementDto.ProductCategoryDto
{
    public class UpdateProductCategoryInputDto : BaseUpdateInputDto
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
    }
}

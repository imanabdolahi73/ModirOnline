using System.ComponentModel.DataAnnotations;
using ModirOnline.Common.BaseClasses;

namespace ModirOnline.Common.Dto.ProductManagementDto.ProductCategoryDto
{
    public class GetProductCategoryInputDto: BaseGetInputDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
